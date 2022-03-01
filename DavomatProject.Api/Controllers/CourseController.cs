using DavomatProject.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseInterface _serviceCourse;

        public CourseController(ICourseInterface serviceCourse)
        {
            _serviceCourse = serviceCourse;
        }
        [HttpGet, Route("getalljson")]
        public async Task<IActionResult> GetallJson()
        {
            var json = await _serviceCourse.GetAllJson();
            return Ok(json);
        }
        [HttpGet, Route("getall")]
        public async Task<IActionResult> Getall()
        {
            
            var modelList = await _serviceCourse.GetAllCourse();
            List<CourseViewModel> vlist = new List<CourseViewModel>();
            foreach (var item in modelList)
            {
                vlist.Add((CourseViewModel)item);
            }
            return Ok(vlist);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _serviceCourse.GetCourse(id);
            return Ok(json);
        }

        [HttpPost, Route("add")] 
        public async Task<IActionResult> Add(Course newCourse)
        {
            var json = await _serviceCourse.AddCourse(newCourse);
            return Ok(json);
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> Update(Course course)
        {
            var json = await _serviceCourse.UpdateCourse(course);
            return Ok(json);
        }

        [HttpDelete, Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceCourse.DeleteCourse(id);
            return Ok();
        }
    }
}
