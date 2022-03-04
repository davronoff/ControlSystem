using Microsoft.AspNetCore.Mvc;
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

        public ServiceController(IServiceInterface serviceInterface)
        {
            _serviceInterface = serviceInterface;
        }
        public  async Task<IActionResult> Services()
        {
            var list = await _serviceInterface.GetAllService();
            List<AddServiceViewModel> viewModels = new List<AddServiceViewModel>();
            foreach (var item in list)
            {
                viewModels.Add((AddServiceViewModel)item);
            }

            return View(viewModels);
        }
        [HttpGet]
        public  IActionResult AddServices()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(AddServiceViewModel newViewModel)
        {
            Service newSerice = await _serviceInterface.AddService((Service)newViewModel);
            return RedirectToAction("Service");
        }
        public IActionResult Delete(Guid id)
        {
            _serviceInterface.DeleteService(id);
            return RedirectToAction("Service");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            AddServiceViewModel viewModel = (AddServiceViewModel)await _serviceInterface.GetService(id);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AddServiceViewModel _editViewModel)
        {
            await _serviceInterface.UpdateService((Service)_editViewModel);
            return RedirectToAction("Service");
        }
    }
}
