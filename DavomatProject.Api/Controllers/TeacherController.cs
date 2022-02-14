using Microsoft.AspNetCore.Mvc;
using Pojectdavomat.BL;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IOqituvchiInterface _teacherService;

        public TeacherController(IOqituvchiInterface teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _teacherService.GetAllOqituvchi();
            return Ok(json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _teacherService.GetOqituvchi(id);
            return Ok(json);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(Oqituvchi newTeacher)
        {
            var json = await _teacherService.AddOqituvchi(newTeacher);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public IActionResult Update(Oqituvchi teacher)
        {
            var json = _teacherService.UpdateOqituvchi(teacher);
            return Ok(json);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teacherService.DeleteOqituvchi(id);
            return Ok();
        }
    }
}
