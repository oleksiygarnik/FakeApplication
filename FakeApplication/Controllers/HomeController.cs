using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FakeApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FakeApplication.Models.UoW;
using FakeApplication.Models.ViewModels;
using FakeApplication.Models.Entities;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace FakeApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //[Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            //return Content($"ваша роль: {role}");
            return View();
        }

        public IActionResult About()
        {
            var comments = _unitOfWork.CommentRepository
                .GetAll()
                .Where(c => c.User.IsBlocked == Models.Entities.BlockStatus.Unblocked);

            User currentUser = new User();

            if (User.Identity.IsAuthenticated)
            {
                var currentUserEmail = User.Identity.Name;

                currentUser = _unitOfWork.UserRepository
                    .GetAll()
                    .FirstOrDefault(u => u.Email == currentUserEmail);

            }
            IndexViewModel model = new IndexViewModel()
            {
                Comments = comments,
                User = currentUser
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Comment(TestimonialModel model)
        {
            var currentUserEmail = User.Identity.Name;

            var currentUser = _unitOfWork.UserRepository
                .GetAll()
                .FirstOrDefault(u => u.Email == currentUserEmail);

            var comment = new Comment()
            {
                Content = model.Content,
                UserId = currentUser.Id,
                DateTime = DateTime.Now
            };

            _unitOfWork.CommentRepository.Add(comment);
            //_unitOfWork.Commit();

            return RedirectToAction("About", "Home");
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
