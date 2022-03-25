using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IDeleteSaveimageInterface _deleteSaveimage;
        private readonly ITeacherInterface _teacherInterface;

        public TeacherController(ITeacherInterface teacherInterface,
            IDeleteSaveimageInterface deleteSaveimage)
        {
            _deleteSaveimage = deleteSaveimage;
            _teacherInterface = teacherInterface;
        }
        public async Task<IActionResult> Teachers()
        {
            var itam = await _teacherInterface.GetAllTeacher();
            return View(itam);
        }
        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addteacher(AddTeacherViewModel viewModel)
        {
            Teacher teacher = new Teacher()
            {
                Id = System.Guid.NewGuid(),
                FirstName = viewModel.FirstName,
                LastaName = viewModel.LastaName,
                Skills = viewModel.Skills,
                Image = viewModel.Image,
                Experince = viewModel.Experince,
                Social = viewModel.Social
            };
            await _teacherInterface.AddTeacher(teacher);

            return RedirectToAction("Teachers");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _teacherInterface.GetTeacher(id);
            return View((EditTeacherViewModel)model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditTeacherViewModel viewModel)
        {
            if (viewModel.NewImage is not null)
            {
                _deleteSaveimage.DeleteImage(viewModel.Image);
                viewModel.Image = await _deleteSaveimage.SaveImageAsync(viewModel.NewImage);
            }
            var model = await _teacherInterface.UpdateTeacher((Teacher)viewModel);
            return RedirectToAction("Teachers");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var teacher = await _teacherInterface.GetTeacher(id);
            _deleteSaveimage.DeleteImage(teacher.Image);
            await _teacherInterface.DeleteTeacher(id);
            return RedirectToAction("Teachers");
        }
    }
}
