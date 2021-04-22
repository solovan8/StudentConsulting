using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentConsulting.Data;
using StudentConsulting.Models;
using StudentConsulting.Business;
using System.Globalization;

namespace StudentConsulting.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class LecturerController : Controller
    {
        IUnitOfWork _unitOfWork;

        IDateFilter _dateFilter;

        IRequestFilter _filter;
        public LecturerController(IUnitOfWork unitOfWork, IRequestFilter filter, IDateFilter dateFilter)
        {
            _unitOfWork = unitOfWork;

            _filter = filter;

            _dateFilter = dateFilter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Today = DateTime.Today.ToString("yyyy-MM-ddTHH:mm");
            ViewBag.MaxDateValue = DateTime.Today.AddMonths(1).ToString("yyyy-MM-ddTHH:mm");

            var lecturerId = _unitOfWork.Lecturers.GetItemByEmail(User.Identity.Name).Id;

            var consultings = _unitOfWork.ConsultingArranges.GetItemsById(lecturerId).OrderBy(c => c.Date);

            return View(_dateFilter.Filter(consultings));
        }

        [HttpPost]
        public IActionResult Index(int durationTime, string consultingDate)
        {
            ConsultingArrange consulting = new ConsultingArrange
            {
                Date = DateTime.ParseExact(consultingDate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture),
                LecturerId = _unitOfWork.Lecturers.GetItemByEmail(User.Identity.Name).Id,
                Duration = durationTime
            };
            _unitOfWork.ConsultingArranges.Create(consulting);
            _unitOfWork.Commit();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Queue(int consultId)
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
    }
}
