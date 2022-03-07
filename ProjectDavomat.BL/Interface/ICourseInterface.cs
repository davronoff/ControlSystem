using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface ICourseInterface
    {
        Task<List<Course>> GetAllCourse();
        Task<Course> GetCourse(Guid id);
        Task<Course> AddCourse(Course newCourse);
        Task<Course> UpdateCourse(Course Course);
        void DeleteCourse(Guid id);

        Task<int> CountCourse();
        Task<List<Course>> GetRandomCourse6();
    }
}