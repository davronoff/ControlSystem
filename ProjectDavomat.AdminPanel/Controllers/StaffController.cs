using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class StaffController : Controller
    {
        private readonly IDeleteSaveimageInterface _deleteSaveimage;
        private readonly IStaffInterface _staffInterface;

        public StaffController(IStaffInterface staffInterface,
            IDeleteSaveimageInterface deleteSaveimage)
        {
            _deleteSaveimage = deleteSaveimage;
            _staffInterface = staffInterface;
        }
        public async Task<IActionResult> Staffs()
        {
            var itam = await _staffInterface.GetAllStaff();
            return View(itam);
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel viewModel)
        {
            Staff staff = new Staff()
            {
                Id = Guid.NewGuid(),
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Image = viewModel.Image,
                About = viewModel.About,
                Position = viewModel.Position,
                Social = viewModel.Social
            };
            await _staffInterface.AddStaff(staff);
            return RedirectToAction("Staffs");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _staffInterface.GetStaff(id);
            return View((EditStaffViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditStaffViewModel viewmodel)
        {
            if(viewmodel.NewImage is not null)
            {
                _deleteSaveimage.DeleteImage(viewmodel.Image);
                viewmodel.Image = await _deleteSaveimage.SaveImageAsync(viewmodel.NewImage);
            }
            var item = await _staffInterface.UpdateStaff((Staff)viewmodel);
            return RedirectToAction("Staffs");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _staffInterface.GetStaff(id);
            _deleteSaveimage.DeleteImage(item.Image);
            await _staffInterface.DeleteStaff(id);
            return RedirectToAction("Staffs");
        }
    }
}
