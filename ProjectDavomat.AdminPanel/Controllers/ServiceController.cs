using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
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
        public async Task<IActionResult> Services()
        {
            var item = await _serviceInterface.GetAllService();
            return View(item);
            
        }
        [HttpGet]
        public IActionResult AddServices()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddServices(AddServiceViewModel newViewModel)
        {
            Service service = new Service()
            {
                Id = Guid.NewGuid(),
                ServiceType = newViewModel.ServiceType,
                Name = newViewModel.Name,
                LifeTimeService = newViewModel.LifeTimeService,
                Price = newViewModel.Price,
                Image = await _deleteSaveimage.SaveImageAsync(newViewModel.Image)

            };
            await _serviceInterface.AddService(service);

            return RedirectToAction("Services");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _serviceInterface.GetService(id);
            return View((EditServiceViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditServiceViewModel viewModel)
        {
            if (viewModel.NewImage is not null)
            {
                _deleteSaveimage.DeleteImage(viewModel.Image);
                viewModel.Image = await _deleteSaveimage.SaveImageAsync(viewModel.NewImage);
            }

            var item = await _serviceInterface.UpdateService((Service)viewModel);
            return RedirectToAction("Services");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var course = await _serviceInterface.GetService(id);
            _deleteSaveimage.DeleteImage(course.Image);
            await _serviceInterface.DeleteService(id);
            return RedirectToAction("Services");
        }

    }
}
