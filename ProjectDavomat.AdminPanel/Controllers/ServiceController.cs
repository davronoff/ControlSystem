using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class ServiceController : Controller
    {
        public async Task<IActionResult> Services()
        {
            return View();
        }
        public async Task<IActionResult> AddServices()
        {
            return View();
        }
    }
}
