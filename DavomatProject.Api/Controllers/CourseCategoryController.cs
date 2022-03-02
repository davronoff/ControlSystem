using DavomatProject.Api.VeiwModel;
using DavomatProject.VeiwModel;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryInterface _serviceCourseCategory;

        public CourseCategoryController(ICourseCategoryInterface serviceCourseCategory)
        {
            _serviceCourseCategory = serviceCourseCategory;
        }
        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var modelList = await _serviceCourseCategory.GetAllCourseCategory();
            List<CategoryViewModel> vlist = new List<CategoryViewModel>();
            foreach (var item in modelList)
            {
                vlist.Add((CategoryViewModel)item);
            }
            return Ok(vlist);
        }
        [HttpGet, Route("getone/{courseName}")]
        public async Task<IActionResult> GetAllJson(string courseName)
        {
            var json = await _serviceCourseCategory.GetCourseCategoryByName(courseName);
            return Ok(json);
        }
        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var json = await _serviceCourseCategory.GetByIdCourseCategory(id);
            return Ok(json);
        }
        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(CategoryViewModel newCourseCategory)
        {
            var json = await _serviceCourseCategory.AddCourseCategory((CourseCategory)newCourseCategory);
            return Ok(json);
        }
        [HttpPut, Route("update")]
        public async Task<IActionResult> Update(CategoryViewModel courseCategory)
        {
            var json = await _serviceCourseCategory.UpdateCourseCategory((CourseCategory)courseCategory);
            return Ok(courseCategory);
        }
        [HttpDelete, Route("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var json =  _serviceCourseCategory.DeleteCurseCategory(id);
            return Ok(json);
        }
    }
}
