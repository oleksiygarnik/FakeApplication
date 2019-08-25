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
    public class Account
    {
        public delegate void AccountStateHandler(string message);

        public event AccountStateHandler Withdrawn;
        public event AccountStateHandler Added;

        double _sum; // Переменная для хранения суммы

        public Account(int sum)
        {
            _sum = sum;
        }

        public double CurrentSum
        {
            get { return _sum; }
        }

        public void Put(double sum)
        {
            _sum += sum;
            if (Added != null)
                Added($"На счет поступило {sum}");
        }
        public void Withdraw(double sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                if (Withdrawn != null)
                    Withdrawn($"Сумма {sum} снята со счета");
            }
            else
            {
                if (Withdrawn != null)
                    Withdrawn("Недостаточно денег на счете");
            }
        }
    }
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
            Account account = new Account(0);

            account.Added += ShowMessage;

            account.Put(user.Money);

            _unitOfWork.UserRepository.Update(user);
            
            return RedirectToAction("Index");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
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
