using Microsoft.AspNetCore.Mvc;
using TeachersManagement.Models;
using TeachersManagement.ViewModels;

namespace TeachersManagement.Controllers
{
    public class TeacherController:Controller
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeacherController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }
        public IActionResult Index()
        {
            TeacherIndexViewModel viewModel = new TeacherIndexViewModel()
            {
                Teachers = _teachersRepository.GetAll()
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(TeacherCreateViewModel teacher)
        {
            if(ModelState.IsValid)
            {
                Teacher newTeacher = new Teacher()
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    DateOfBirth = teacher.DateOfBirth,
                    Experience = teacher.Experience,
                    Specialty = teacher.Specialty

                };
                newTeacher = _teachersRepository.Create(newTeacher);
                return RedirectToAction("details","teacher", new {id=newTeacher.Id});
            }
            else
            {
                return View();
            }         

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            TeacherDetailsViewModel viewModel = new TeacherDetailsViewModel()
            {
                Teacher = _teachersRepository.Get(id),
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Teacher teacher = _teachersRepository.Get(id);
            TeacherUpdateViewModel viewModel = new TeacherUpdateViewModel()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                Experience = teacher.Experience,
                Specialty = teacher.Specialty,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(TeacherUpdateViewModel teacher)
        {
            if(ModelState.IsValid)
            {
                Teacher existTeacher = _teachersRepository.Get(teacher.Id);
                existTeacher.FirstName = teacher.FirstName;
                existTeacher.LastName = teacher.LastName;
                existTeacher.DateOfBirth = teacher.DateOfBirth;
                existTeacher.Specialty = teacher.Specialty;
                existTeacher.Experience = teacher.Experience;
                 _teachersRepository.Update(existTeacher);

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Teacher teacher = _teachersRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
