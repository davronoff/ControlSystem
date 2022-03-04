using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseInterface _courseInterface;
        
        public CourseController(ICourseInterface courseInterface)
        {
            _courseInterface = courseInterface;
        }
        public async Task<IActionResult> Courses()
        {
            var itam = await _courseInterface.GetAllCourse();
            return View(itam);
        }
        public async Task<IActionResult> AddCourses()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _courseInterface.GetCourse(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            var item = await _courseInterface.UpdateCourse(course);
            return RedirectToAction("Courses");
        }
    }
}
