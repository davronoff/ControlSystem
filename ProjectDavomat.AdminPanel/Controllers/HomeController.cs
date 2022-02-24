using Microsoft.AspNetCore.Mvc;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
