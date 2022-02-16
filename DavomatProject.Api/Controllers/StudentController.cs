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
        private readonly IUserInterface _serviceStudent;

        public StudentController(IUserInterface serviceStudent)
        {
            _serviceStudent = serviceStudent;
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _serviceStudent.GetAllUser();
            return Ok(json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _serviceStudent.GetUser(id);
            return Ok(json);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(User newOquvchi)
        {
            var json = await _serviceStudent.AddUser(newOquvchi);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public IActionResult Update(User student)
        {
            var json = _serviceStudent.UpdateUser(student);
            return Ok(json);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceStudent.DeleteUser(id);
            return Ok();
        }
    }  
}
