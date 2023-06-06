using Microsoft.AspNetCore.Mvc;

namespace TeachersManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FormSubmit(string teacherOrPupil)
        {
            if (teacherOrPupil == "teacher")
            {
                return RedirectToAction("create", "teacher");
            }
            else if(teacherOrPupil == "pupil")
            {
                return RedirectToAction("create", "pupil");
            }
            return View();
        }
    }
}
