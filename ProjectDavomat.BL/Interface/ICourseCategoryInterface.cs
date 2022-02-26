using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface ICourseCategoryInterface
    {
        Task<List<CourseCategory>> GetAll();
        Task<CourseCategory> GetByIdCourseCategory(Guid id);
        Task<CourseCategory> AddCourseCategory(CourseCategory newCourseCategory);
        Task<CourseCategory> UpdateCourseCategory(CourseCategory courseCategory);
        Task DeleteCurseCategory(Guid id);
    }
}
