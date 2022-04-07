using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Data.DataLayer;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStatInterface _statInterface;
        private readonly AppDbContext _dbContext;

        public HomeController(IStatInterface statInterface,
                              AppDbContext dbContext)
        {
            _statInterface = statInterface;
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            var statistics = _statInterface.GetAllStatistics();
            return View(statistics);
        }
    }
}
