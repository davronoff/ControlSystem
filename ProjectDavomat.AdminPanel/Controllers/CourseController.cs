using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseInterface _courseInterface;
        private readonly IDeleteSaveimageInterface _imageService;
        private readonly ICourseCategoryInterface _categoryInterface;

        public CourseController(ICourseInterface courseInterface,
                                IDeleteSaveimageInterface imageService,
                                ICourseCategoryInterface categoryInterface)
        {
            _courseInterface = courseInterface;
            _imageService = imageService;
            _categoryInterface = categoryInterface;
        }
        public async Task<IActionResult> Courses()
        {
            var itam = await _courseInterface.GetAllCourse();
            return View(itam);
        }
        [HttpGet]
        public async Task<IActionResult> AddCourses()
        {
            List<string> Categories = new List<string>();
            var list = await _categoryInterface.GetAllCourseCategory();
            foreach(var item in list)
            {
                Categories.Add(item.Name);
            }

            AddCourseViewModel viewModel = new AddCourseViewModel()
            {
                Categories = Categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourses(AddCourseViewModel viewModel)
        {
            var list = await _categoryInterface.GetAllCourseCategory();
            var category = list.FirstOrDefault(c => c.Name == viewModel.CourseCategoryName);
            Course course = new Course()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Duration = viewModel.Duration,
                Image = _imageService.SaveImage(viewModel.Image),
                CourseCategoryId = category.Id
            };

            await _courseInterface.AddCourse(course);

            return RedirectToAction("Courses");
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

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var course = await _courseInterface.GetCourse(id);
            _imageService.DeleteImage(course.Image);
            await _courseInterface.DeleteCourse(id);
            return RedirectToAction("Courses");
        }
    }
}
