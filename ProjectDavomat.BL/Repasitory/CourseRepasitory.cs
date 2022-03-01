using Microsoft.EntityFrameworkCore;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Data.DataLayer;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Repasitory
{
    public class CourseRepasitory : ICourseInterface
    {
        private readonly AppDbContext _dbCourse;

        public CourseRepasitory(AppDbContext dbCourse)
        {
            _dbCourse = dbCourse;
        }
        public Task<Course> AddCourse(Course newCourse)
        {
            _dbCourse.courses.Add(newCourse);
            _dbCourse.SaveChanges();
            return Task.FromResult(newCourse);
        }

        public Task DeleteCourse(Guid id)
        {
            Course course = _dbCourse.courses.FirstOrDefault(p => p.Id == id);
            _dbCourse.courses.Remove(course);
            _dbCourse.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Course>> GetAllCourse() => _dbCourse.courses.ToListAsync();

        public Task<List<Course>> GetAllJson()
        {
            return _dbCourse.courses
            .Include(p => p.Teacher).ToListAsync();
        }

        public Task<Course> GetCourse(Guid id) => _dbCourse.courses.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Course> UpdateCourse(Course Course)
        {
            _dbCourse.courses.Update(Course);
            _dbCourse.SaveChanges();
            return Task.FromResult(Course);
        }
    }
}