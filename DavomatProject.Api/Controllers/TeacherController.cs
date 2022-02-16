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
        private readonly ITeacherInterface _teacherService;

        public TeacherController(ITeacherInterface teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _teacherService.GetAllTeacher();
            return Ok(json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _teacherService.GetTeacher(id);
            return Ok(json);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(Teacher newTeacher)
        {
            var json = await _teacherService.AddTeacher(newTeacher);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public IActionResult Update(Teacher teacher)
        {
            var json = _teacherService.UpdateTeacher(teacher);
            return Ok(json);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teacherService.DeleteTeacher(id);
            return Ok();
        }
    }
}
