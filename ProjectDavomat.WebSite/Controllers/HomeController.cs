using Microsoft.AspNetCore.Mvc;

namespace ProjectDavomat.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }    
}
