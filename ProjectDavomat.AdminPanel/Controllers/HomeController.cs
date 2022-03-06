using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseInterface _courseInterface;

        public HomeController(ICourseInterface courseInterface)
        {
            _courseInterface = courseInterface;    
        }
        public async Task<IActionResult> Index()
        {
            var item = await _courseInterface.GetAllCourse();
            return View(item);
        }
    }
}
