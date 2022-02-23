using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("[api/controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceInterface _serviceService;

        public ServiceController(IServiceInterface serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet, Route ("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _serviceService.GetAllService();
            return Ok(json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = _serviceService.GetService(id);
            return Ok(json);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(Service newService)
        {
            var json = await _serviceService.AddService(newService);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update(Service servcie)
        {
            var json = _serviceService.UpdateService(servcie);
            return Ok(servcie);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceService.DeleteService(id);
            return Ok();
        }
    }
}
