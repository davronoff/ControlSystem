using DavomatProject.VeiwModel;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICourseCategoryInterface _service;

        public CategoryController(ICourseCategoryInterface service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllCourseCategory();
            List<CategoryViewModel> viewModels = new List<CategoryViewModel>();
            foreach (var item in list)
            {
                viewModels.Add((CategoryViewModel)item);
            }

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel viewModel)
        {
            CourseCategory category = await _service.AddCourseCategory((CourseCategory)viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _service.DeleteCurseCategory(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            CategoryViewModel viewModel = (CategoryViewModel)await _service.GetByIdCourseCategory(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel viewModel)
        {
            await _service.UpdateCourseCategory((CourseCategory)viewModel);
            return RedirectToAction("Index");
        }
    }
}
