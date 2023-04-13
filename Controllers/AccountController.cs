using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;
using Exercise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ManagementContext _context;

        public AccountController(IAccountRepository accountReopsitory, ManagementContext context)
        {
            _accountRepository = accountReopsitory;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            var result = _accountRepository.RegisterUser(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAdmin(RegisterVM registerVM)
        {
            var result = _accountRepository.RegisterAdmin(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login(string url = "") 
        {
            var model = new LoginVM { ReturnUrl = url };
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var employee = _context.Employees.Include(e => e.Accounts).FirstOrDefault(e => e.Email == model.Email); 
            if (employee != null && employee.Accounts != null && employee.Accounts.Password == model.Password)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or password do not match.");
                return View(model);
            }
        }
    }
}