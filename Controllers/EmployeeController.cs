using EmployeeApp.Models;
using Exercise.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeReopsitory _employeeRepository;

        public EmployeeController(IEmployeeReopsitory employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entity = _employeeRepository.GetAll();
            return View(entity);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var entity = _employeeRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            _employeeRepository.Insert(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var entity = _employeeRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var entity = _employeeRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string nik)
        {
            _employeeRepository.Delete(nik);
            return RedirectToAction("Index");
        }
    }
}
