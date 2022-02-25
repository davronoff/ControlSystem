using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class TeacherController : Controller
    {
        public async Task<IActionResult> Teachers()
        {
            return View();
        }
    }
}
