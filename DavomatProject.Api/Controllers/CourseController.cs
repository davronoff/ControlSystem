using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    public class CourseController : ControllerBase
    {
        private readonly ICourseInterface _serviceCourse;

        public CourseController(ICourseInterface serviceCourse)
        {
            _serviceCourse = serviceCourse;
        }

        [Route("getall")]
        public async Task<IActionResult> Getall()
        {
            var json = await _serviceCourse.GetAllCourse();
            return Ok(json);
        }

        [Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _serviceCourse.GetCourse(id);
            return Ok(json);
        }

        [Route("add")] 
        public async Task<IActionResult> Add(Course newCourse)
        {
            var json = await _serviceCourse.AddCourse(newCourse);
            return Ok(json);
        }

        [Route("update")]
        public async Task<IActionResult> Update(Course course)
        {
            var json = await _serviceCourse.UpdateCourse(course);
            return Ok(json);
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceCourse.DeleteCourse(id);
            return Ok();
        }
    }
}
