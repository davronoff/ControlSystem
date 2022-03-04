using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class LeaderController : Controller
    {
        private readonly ILeaderInterface _leaderInterface;

        public LeaderController(ILeaderInterface leaderInterface)
        {
            _leaderInterface = leaderInterface;
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
        public async Task<IActionResult> Add(Leader newLeader)
        {
            var json = await _leaderInterface.AddLeader(newLeader);
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
    }
}
