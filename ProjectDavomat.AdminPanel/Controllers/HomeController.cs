using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Data.DataLayer;
using ProjectDavomat.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseInterface _courseservice;
        private readonly ILeaderInterface _leaderservice;
        private readonly IServiceInterface _service;
        private readonly IStaffInterface _staffservice;
        private readonly ITeacherInterface _teacherservice;
        private readonly AppDbContext _dbContext;

        public HomeController(ICourseInterface courseservice,
                              ILeaderInterface leaderservice,
                              IServiceInterface service,
                              IStaffInterface staffservice,
                              ITeacherInterface teacherservice,
                              AppDbContext dbContext)
        {
            _courseservice = courseservice;
            _leaderservice = leaderservice;
            _service = service;
            _staffservice = staffservice;
            _teacherservice = teacherservice;
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index(AllStatisticViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
