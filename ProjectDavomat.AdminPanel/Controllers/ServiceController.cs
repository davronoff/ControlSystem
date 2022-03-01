using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceInterface _serviceInterface;

        public ServiceController(IServiceInterface serviceInterface)
        {
            _serviceInterface = serviceInterface;
        }
        public  async Task<IActionResult> Services()
        {
            var item = await _serviceInterface.GetAllService();
            return View(item);
        }
        public async Task<IActionResult> AddServices()
        {
            return View();
        }
    }
}
