using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StudentConsulting.Models;
using StudentConsulting.Data;
using Microsoft.AspNetCore.Identity;

namespace StudentConsulting.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IUnitOfWork _unitOfWork;
        UserManager<IdentityUser> _userManager;

        public AdminController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;

            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddLecturer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLecturer(Lecturer lecturer)
        {
            _unitOfWork.Lecturers.Create(lecturer);

            var lecturerBody = new IdentityUser { Email = lecturer.Email, UserName = lecturer.Email, EmailConfirmed = true };

            var lecturerResult = _userManager.CreateAsync(lecturerBody, "User123!").GetAwaiter().GetResult();

            if (lecturerResult.Succeeded)
                _userManager.AddToRoleAsync(lecturerBody, "Lecturer").GetAwaiter().GetResult();
            
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}
