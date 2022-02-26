using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class CourseController : Controller
    {
        public async Task<IActionResult> Courses()
        {
            return View();
        }
        public async Task<IActionResult> AddCourses()
        {
            return View();
        }
    }
}
