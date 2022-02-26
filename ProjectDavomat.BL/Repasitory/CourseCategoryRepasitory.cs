using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Repasitory
{
    public class CourseCategoryRepasitory : ICourseCategoryInterface
    {
        public Task<CourseCategory> AddCourseCategory(CourseCategory newCourseCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCurseCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CourseCategory> GetByIdCourseCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseCategory> UpdateCourseCategory(CourseCategory courseCategory)
        {
            throw new NotImplementedException();
        }
    }
}
