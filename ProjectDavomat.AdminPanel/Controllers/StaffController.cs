using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class StaffController : Controller
    {
        public async Task<IActionResult> Staffs()
        {
            return View();
        }
        public async Task<IActionResult> AddStaffs()
        {
            return View();
        }
    }
}
