using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://ilyosbek.uz/rtm/api/images/save");


            byte[] imageBytes;
            using(var ms = new MemoryStream())
            {
                viewModel.Image.CopyTo(ms);
                imageBytes = ms.ToArray();
            }
            
            //var json = JsonConvert.SerializeObject(image);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            //var res = client.PostAsync(client.BaseAddress, data).Result;

           // string imageFileName = res.Content.ToString();

            var list = await _categoryInterface.GetAllCourseCategory();
            var category = list.FirstOrDefault(c => c.Name == viewModel.CourseCategoryName);
            Course course = new Course()
            {
                Id = Guid.NewGuid(),
                Title = viewModel.Title,
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Duration = viewModel.Duration,
                Image = await _imageService.SaveImageAsync(viewModel.Image),
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
                _imageService.DeleteImageAsync(viewModel.Image);
                viewModel.Image = await _imageService.SaveImageAsync(viewModel.NewImage);
            }

            var item = await _courseInterface.UpdateCourse((Course)viewModel);
            return RedirectToAction("Courses");
        }

        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var course = await _courseInterface.GetCourse(id);
            _imageService.DeleteImageAsync(course.Image);
            await _courseInterface.DeleteCourse(id);
            return RedirectToAction("Courses");
        }
    }
}
