using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseInterface _courseInterface;
        private readonly IDeleteSaveimageInterface _imageService;

        public CourseController(ICourseInterface courseInterface,
                                IDeleteSaveimageInterface imageService)
        {
            _courseInterface = courseInterface;
            _imageService = imageService;
        }
        public async Task<IActionResult> Courses()
        {
            var itam = await _courseInterface.GetAllCourse();
            return View(itam);
        }
        public async Task<IActionResult> AddCourses()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _courseInterface.GetCourse(id);

            return View((EditCourseViewModel)item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCourseViewModel viewModel)
        {
            if (viewModel.NewImage is not null)
            {
                _imageService.DeleteImage(viewModel.Image);
                viewModel.Image = _imageService.SaveImage(viewModel.NewImage);
            }

            var item = await _courseInterface.UpdateCourse((Course)viewModel);
            return RedirectToAction("Courses");
        }
    }
}
