using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("[api/controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffInterface _staffSerice;

        public StaffController(IStaffInterface staffService)
        {
            _staffSerice = staffService;
        }

        [HttpGet,Route("gettall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _staffSerice.GetAllStaff();
            return Ok(json);
        }

        [HttpGet,Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _staffSerice.GetStaff(id);
            return Ok(json);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(Staff newStaff)
        {
            var json = await _staffSerice.AddStaff(newStaff);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update(Staff staff)
        {
            var json = await _staffSerice.UpdateStaff(staff);
            return Ok(staff);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _staffSerice.DeleteStaff(id);
            return Ok();
        }
    }
}
