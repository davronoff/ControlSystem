using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
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
    }
}
