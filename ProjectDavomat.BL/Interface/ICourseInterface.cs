using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface ICourseInterface
    {
        Task<List<Course>> GetAllCourse();
        Task<List<Course>> GetAllJson();
        Task<Course> GetCourse(Guid id);
        Task<Course> AddCourse(Course newCourse);
        Task<Course> UpdateCourse(Course Course);
        Task DeleteCourse(Guid id);
    }
}