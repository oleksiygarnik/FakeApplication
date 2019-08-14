using FakeApplication.Models.Entities;
using FakeApplication.Models.UoW;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _unitOfWork.UserRepository.GetAll();

            return View(users.ToList());
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            
            return RedirectToAction("Index");
        }

        public ActionResult BlockUser(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            if (user != null)
            {
                user.IsBlocked = BlockStatus.Blocked;

                _unitOfWork.UserRepository.Update(user);
            }
            return RedirectToAction("Index");
        }
    }
}
