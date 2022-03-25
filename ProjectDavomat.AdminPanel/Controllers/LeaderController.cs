using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.AdminPanel.Services;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using ProjectDavomat.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Controllers
{
    public class LeaderController : Controller
    {
        private readonly IDeleteSaveimageInterface _deleteSaveimage;
        private readonly ILeaderInterface _leaderInterface;

        public LeaderController(ILeaderInterface leaderInterface,
                                IDeleteSaveimageInterface deleteSaveimage)
        {
            _deleteSaveimage = deleteSaveimage;
            _leaderInterface = leaderInterface;
        }
        public async Task<IActionResult> Leaders()
        {
            var item = await _leaderInterface.GetAllLeader();
            return View(item);
        }
        [HttpGet] 
        public IActionResult Addleader()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addleader(AddLeaderViewModel viewModel)
        {
            Leader leader = new Leader()
            {
                Id = System.Guid.NewGuid(),
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Position = viewModel.Position,
                Image = await _deleteSaveimage.SaveImageAsync(viewModel.Image)
            };
            await _leaderInterface.AddLeader(leader);
            return RedirectToAction("Leaders");
        }
        [HttpGet]
        public async Task<IActionResult> Editleader(Guid id)
        {
            var item = await _leaderInterface.GetLeader(id);

            return View((EditLeaderViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Editleader(EditLeaderViewModel viewModel)
        {
            if (viewModel.NewImage is not null)
            {
                _deleteSaveimage.DeleteImage(viewModel.Image);
                viewModel.Image = await _deleteSaveimage.SaveImageAsync(viewModel.NewImage);
            }

            var item = await _leaderInterface.UpdateLeader((Leader)viewModel);
            return RedirectToAction("Leaders");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var leader = await _leaderInterface.GetLeader(id);
            _deleteSaveimage.DeleteImage(leader.Image);
            await _leaderInterface.DeleteLeader(id);
            return RedirectToAction("Leaders");
        }
    }
}
