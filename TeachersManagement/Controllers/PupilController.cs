using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using TeachersManagement.Models;
using TeachersManagement.ViewModels;

namespace TeachersManagement.Controllers
{
    public class PupilController : Controller
    {
        private readonly IPupilsRepository _pupilsRepository;
        private readonly ITeachersRepository _teacher;

        public PupilController(IPupilsRepository pupilsRepository, ITeachersRepository teacher)
        {
            _pupilsRepository = pupilsRepository;
            _teacher = teacher;
        }
        public IActionResult Index()
        {
            PupilIndexViewModel viewModel = new PupilIndexViewModel()
            {
                Pupils = _pupilsRepository.GetAllPupils(),
            };
            return View(viewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Teachers = _teacher.GetAll().Select(x => new { TeacherId = x.Id, TName = x.FirstName });

            return View();
        }
        [HttpPost]
        public IActionResult Create(PupilCreateViewModel pupil, string? TName)
        {
            if (ModelState.IsValid)
            {
                Pupil newPupil = new Pupil()
                {
                    Id = pupil.Id,
                    FullName = pupil.FullName,
                    Old = pupil.Old,
                    Grade = pupil.Grade,
                    TName = TName
                };
                ViewBag.Teachers = _teacher.GetAll().Select(x => new { TeacherId = x.Id, TName = x.FirstName });
                newPupil = _pupilsRepository.Create(newPupil);
                return RedirectToAction("details", "pupil", new { id = newPupil.Id });
            }
            else
            {
                ViewBag.Teachers = _teacher.GetAll().Select(x => new { TeacherId = x.Id, TName = x.FirstName });
                return View();
            }

        }
        [HttpGet]
        public ViewResult Details(int? id)
        {
            PupilDetailsViewModel viewModel = new PupilDetailsViewModel()
            {
                Pupil = _pupilsRepository.GetPupil(id ?? 0)
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            if (ModelState.IsValid)
            {

                Pupil pupil = _pupilsRepository.GetPupil(id);
                ViewBag.Teachers = _teacher.GetAll().Select(x => new { TeacherId = x.Id, TName = x.FirstName });
                PupilUpdateViewModel viewModel = new PupilUpdateViewModel()
                {
                    Id = pupil.Id,
                    FullName = pupil.FullName,
                    Old = pupil.Old,
                    Grade = pupil.Grade,
                };
                return View(viewModel);

            }

            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Update(PupilUpdateViewModel pupil)
        {
            if (ModelState.IsValid)
            {
                Pupil existPupil = _pupilsRepository.GetPupil(pupil.Id);
                existPupil.FullName = pupil.FullName;
                existPupil.Old = pupil.Old;
                existPupil.Grade = pupil.Grade;
                //existPupil.Educator = pupil.Educator;

                existPupil = _pupilsRepository.Update(existPupil);

                return RedirectToAction("index");
            }
            return View();

        }

        public IActionResult Delete(int id)
        {
            Pupil pupil = _pupilsRepository.Delete(id);
            return RedirectToAction("index");
        }
    }
}
