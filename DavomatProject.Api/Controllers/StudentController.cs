using Microsoft.AspNetCore.Mvc;
using Pojectdavomat.BL;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IOquvchiInterface _serviceStudent;

        public StudentController(IOquvchiInterface serviceStudent)
        {
            _serviceStudent = serviceStudent;
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _serviceStudent.GetAllOquvchi();
            return Ok(json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _serviceStudent.GetOquvchi(id);
            return Ok(json);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(Oquvchi newOquvchi)
        {
            var json = await _serviceStudent.AddOquvchi(newOquvchi);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public IActionResult Update(Oquvchi student)
        {
            var json = _serviceStudent.UpdateOquvchi(student);
            return Ok(json);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceStudent.DeleteOquvchi(id);
            return Ok();
        }
    }  
}
