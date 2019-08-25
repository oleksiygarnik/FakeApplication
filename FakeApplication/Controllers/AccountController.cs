using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FakeApplication.Models.EfDataContext;
using FakeApplication.Models.Entities;
using FakeApplication.Models.Repositories;
using FakeApplication.Models.UoW;
using FakeApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FakeApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = (_unitOfWork.UserRepository as UserRepository).GetUserByEmailAndPassword(model.Email, model.Password);

                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("About", "Home");
                }
                else
                {
                    ModelState.AddModelError("loginModel.Email", "Некорректные логин и(или) пароль");
                }

            }

            //return null;
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = (_unitOfWork.UserRepository as UserRepository).GetUserByEmail(model.Email);

                if (user == null)
                {
                    user = new User { Login = model.Login, Email = model.Email, Password = model.Password, Money = 0, IsBlocked = BlockStatus.Unblocked };

                    Role userRole = (_unitOfWork.RoleRepository as RoleRepository).GetRoleByName("user");
                    if (userRole != null)
                        user.RoleId = userRole.Id;


                    _unitOfWork.UserRepository.Add(user);

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("About", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }


            }
            return View(model);

        }

        private async Task Authenticate(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("About", "Home");
        }

    }
}