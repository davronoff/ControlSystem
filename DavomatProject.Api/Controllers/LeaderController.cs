using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LeaderController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILeaderInterface _leaderInterface;

        public LeaderController(ILeaderInterface leaderInterface,
            IWebHostEnvironment environment)
        {
            _environment = environment;
            _leaderInterface = leaderInterface;
        }
        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }



        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _leaderInterface.GetAllLeader();
            return Ok(json);
        }
        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _leaderInterface.GetLeader(id);
            return Ok(json);
        } 
        [HttpPost, Route("add")]
        public async Task<ActionResult<EmployeeModel>> Add([FromForm]Leader newLeader)
        {
            var json = await _leaderInterface.AddLeader(newLeader );
            return Ok(json);
        }
        [HttpPut, Route("update")]
        public async Task<IActionResult> Update(Leader leader)
        {
            var json = await _leaderInterface.UpdateLeader(leader);
            return Ok(json);
        }
        [HttpDelete, Route("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var json =  _leaderInterface.DeleteLeader(id);
            return Ok(json);
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_environment.ContentRootPath, "images", imageName);
            using(var filestream = new FileStream(imagePath,FileMode.Create))
            {
                await imageFile.CopyToAsync(filestream);
            }
            return imageName;
        }
    }
}
