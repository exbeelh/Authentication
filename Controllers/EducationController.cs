using EmployeeApp.Models;
using Exercise.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exercise.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        
        private readonly IUniversityRepository _universityRepository;

        public EducationController(IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }        

        [HttpGet]
        public IActionResult Index()
        {
            var entity = _educationRepository.GetAll();
            return View(entity);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var universities = _universityRepository.GetAll();
            var selectedListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.UniversityId = selectedListUniversities;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            _educationRepository.Insert(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var universities = _universityRepository.GetAll();
            var selectedListUniversities = universities.Select(u => new SelectListItem()
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.UniversityId = selectedListUniversities;

            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Education education)
        {
            _educationRepository.Update(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _educationRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _educationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
