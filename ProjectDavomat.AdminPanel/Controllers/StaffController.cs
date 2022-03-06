using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffInterface _staffInterface;

        public StaffController(IStaffInterface staffInterface)
        {
            _staffInterface = staffInterface;
        }
        public async Task<IActionResult> Staffs()
        {
            var itam = await _staffInterface.GetAllStaff();
            return View(itam);
        }
        public  IActionResult AddStaffs()
        {
            return View();
        }
    }
}
