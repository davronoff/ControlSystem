using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherInterface _teacherInterface;

        public TeacherController(ITeacherInterface teacherInterface)
        {
            _teacherInterface = teacherInterface;
        }
        public async Task<IActionResult> Teachers()
        {
            var itam = await _teacherInterface.GetAllTeacher();
            return View(itam);
        }
        public IActionResult AddTeachers()
        {
            return View();
        }
    }
}
