using EmployeeApp.Models;
using Exercise.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Exercise.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entities = _universityRepository.GetAll();
            return View(entities);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entities = _universityRepository.GetById(id);
            return View(entities);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(University university)
        {
            _universityRepository.Insert(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(University university)
        {
            _universityRepository.Update(university);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _universityRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _universityRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
