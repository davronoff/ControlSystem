using Microsoft.EntityFrameworkCore;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Data.DataLayer;
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
        private readonly AppDbContext _courseCategoryservice;

        public CourseCategoryRepasitory(AppDbContext courseCategoryservice)
        {
            _courseCategoryservice = courseCategoryservice;
        }
        public Task<CourseCategory> AddCourseCategory(CourseCategory newCourseCategory)
        {
            _courseCategoryservice.courseCategories.Add(newCourseCategory);
            _courseCategoryservice.SaveChanges();
            return Task.FromResult(newCourseCategory);
        }

        public Task DeleteCurseCategory(Guid id)
        {
            CourseCategory courseCategory = _courseCategoryservice.courseCategories.FirstOrDefault(p => p.Id == id);
            _courseCategoryservice.courseCategories.Remove(courseCategory);
            _courseCategoryservice.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<CourseCategory>> GetAll() => _courseCategoryservice.courseCategories.ToListAsync();

        public Task<CourseCategory> GetByIdCourseCategory(Guid id) => _courseCategoryservice.courseCategories.FirstOrDefaultAsync(p => p.Id == id);

        public Task<CourseCategory> UpdateCourseCategory(CourseCategory courseCategory)
        {
            _courseCategoryservice.courseCategories.Update(courseCategory);
            _courseCategoryservice.SaveChanges();
            return Task.FromResult(courseCategory);
        }
    }
}
