﻿using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceInterface _serviceService;

        public ServiceController(IServiceInterface serviceService)
        {
            _serviceService = serviceService;
        }

        [Route ("getall")]
        public async Task<IActionResult> GetAll()
        {
            var json = await _serviceService.GetAllService();
            return Ok(json);
        }

        [Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = _serviceService.GetService(id);
            return Ok(json);
        }

        [Route("add")]
        public async Task<IActionResult> Add(Service newService)
        {
            var json = await _serviceService.AddService(newService);
            return Ok(json);
        }

        [Route("update")]
        public async Task<IActionResult> Update(Service servcie)
        {
            var json = _serviceService.UpdateService(servcie);
            return Ok(servcie);
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceService.DeleteService(id);
            return Ok();
        }
    }
}
