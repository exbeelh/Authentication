using EmployeeApp.Models;
using Exercise.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entity = _roleRepository.GetAll();
            return View(entity);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Role role)
        {
            _roleRepository.Insert(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role role) 
        {
            _roleRepository.Update(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _roleRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _roleRepository.Delete(id);
            return Redirect("Index");
        }

    }
}
