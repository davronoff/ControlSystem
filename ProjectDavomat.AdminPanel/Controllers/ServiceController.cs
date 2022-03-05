using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceInterface _serviceInterface;
        private readonly IDeleteSaveimageInterface _deleteSaveimage;

        public ServiceController(IServiceInterface serviceInterface,
            IDeleteSaveimageInterface deleteSaveimage)
        {
            _serviceInterface = serviceInterface;
            _deleteSaveimage = deleteSaveimage;
        }
        public  async Task<IActionResult> Services()
        {
            var viewModel = await _serviceInterface.GetAllService();
            List<AddServiceViewModel> viewModels = new List<AddServiceViewModel>();
            foreach (var item in viewModels)
            {
                viewModels.Add((AddServiceViewModel)item);
            }

            return View(viewModels);
            
        }
        [HttpGet]
        public  IActionResult AddServices()
        {
            var item = _serviceInterface.GetAllService();
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(AddServiceViewModel newViewModel)
        {
            var item = _serviceInterface.GetAllService();
            AddCourseViewModel newService = new AddCourseViewModel();
            {
                
            }
            return RedirectToAction("Service");
        }
        public IActionResult Delete(Guid id)
        {
            _serviceInterface.DeleteService(id);
            return RedirectToAction("Service");
        }
        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    AddServiceViewModel viewModel = (AddServiceViewModel)await _serviceInterface.GetService(id);
        //    return View(viewModel);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(AddServiceViewModel _editViewModel)
        //{
        //    if (_editViewModel.NewImage is not null)
        //    {
        //        _deleteSaveimage.DeleteImage(_editViewModel.Image);
        //        _editViewModel.Image = _deleteSaveimage.SaveImage(_editViewModel.NewImage);
        //    }

        //    var item = await _serviceInterface.UpdateService((Service)_editViewModel);
        //    return RedirectToAction("Service");
        //}
    }
}
