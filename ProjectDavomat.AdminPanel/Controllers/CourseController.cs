using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
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
    }
}
