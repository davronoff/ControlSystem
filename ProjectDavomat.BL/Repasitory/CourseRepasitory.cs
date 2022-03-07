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

        public void DeleteCourse(Guid id)
        {
            Course course = _dbCourse.courses.Where(p => p.Id == id).FirstOrDefault();
            _dbCourse.courses.Remove(course);
            _dbCourse.SaveChanges();
        }

        public Task<List<Course>> GetAllCourse() => _dbCourse.courses.ToListAsync();

        public Task<Course> GetCourse(Guid id) => _dbCourse.courses.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Course> UpdateCourse(Course Course)
        {
            _dbCourse.courses.Update(Course);
            _dbCourse.SaveChanges();
            return Task.FromResult(Course);
        }

        //get count of courses
        public Task<int> CountCourse()
        {
            return Task.FromResult(_dbCourse.courses.Count());
        }
        
        //get random 6 courses
        public Task<List<Course>> GetRandomCourse6()
        {
            if (_dbCourse.courses.Count() <= 6)
            {
                return _dbCourse.courses.ToListAsync();
            }
            else
            {
                return _dbCourse.courses.Take(6).ToListAsync();
            }
        }
    }
}