using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class KursController : Controller
    {
        public async Task<IActionResult> Courses()
        {
            return View();
        }
    }
}
