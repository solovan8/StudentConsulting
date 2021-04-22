using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentConsulting.Data;
using StudentConsulting.Models;
using StudentConsulting.Business;

namespace StudentConsulting.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        IUnitOfWork _unitOfWork;

        IRequestFilter _filter;

        IDateFilter _dateFilter;

        public StudentController(IUnitOfWork unitOfWork, IRequestFilter filter, IDateFilter dateFilter)
        {
            _unitOfWork = unitOfWork;

            _filter = filter;

            _dateFilter = dateFilter;
        }

        public IActionResult Index()
        {
            var lecturer = _unitOfWork.Lecturers.GetItems();
            return View(lecturer);
        }

        public IActionResult Choose(int lecturerId)
        {
            var lecturer = _unitOfWork.Lecturers.GetItem(lecturerId);

            ViewBag.LecturerName = $"{lecturer.FirstName} {lecturer.LastName}";
            ViewBag.Subject = lecturer.Subject;

            var arrangedConsultings = _unitOfWork.ConsultingArranges.GetItemsById(lecturerId).OrderBy(d => d.Date);

            return View(_dateFilter.Filter(arrangedConsultings));
        }

        [HttpGet]
        public IActionResult Schedule(int consultId)
        {
            var consult = _unitOfWork.ConsultingArranges.GetItem(consultId);
            var lecturer = _unitOfWork.Lecturers.GetItem(consult.LecturerId);

            ViewBag.Id = consultId;
            ViewBag.Duration = consult.Duration;
            ViewBag.Date = consult.Date;
            ViewBag.Name = $"{lecturer.FirstName} {lecturer.LastName}";
            ViewBag.Subject = lecturer.Subject;

            return View(_filter.Prioritize(consultId));
        }

        [HttpPost]
        public IActionResult Schedule(int consultType, int requiredTime, int Id)
        {
            ConsultType type;
            switch(consultType) {
                case 3:
                    type = ConsultType.Passing;
                    break;
                case 2:
                    type = ConsultType.Code;
                    break;
                case 1:
                default:
                    type = ConsultType.Theoretical;
                    break;
            }

            var request = new ConsultingRequest
            {
                ConsultType = type,
                RequiredTime = requiredTime,
                ConsultingArrangeId = Id,
                StudentId = _unitOfWork.Students.GetItemByEmail(User.Identity.Name).Id
            };

            _unitOfWork.ConsultingRequests.Create(request);
            _unitOfWork.Commit();

            return RedirectToAction("Schedule","Student", new { consultId = Id});
        }
    }
}
