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
    public class TeacherRepasitory : ITeacherInterface
    {
        private readonly AppDbContext _dbTeacher;

        public TeacherRepasitory(AppDbContext dbTeacher)
        {
            _dbTeacher = dbTeacher;
        }
        public Task<Teacher> AddTeacher(Teacher newTeacher)
        {
            _dbTeacher.teachers.Add(newTeacher);
            _dbTeacher.SaveChanges();
            return Task.FromResult(newTeacher);
        }

        public Task DeleteTeacher(Guid id)
        {
            Teacher teacher = _dbTeacher.teachers.FirstOrDefault(p => p.Id == id);
            _dbTeacher.teachers.Remove(teacher);
            _dbTeacher.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Teacher>> GetAllTeacher() => _dbTeacher.teachers.ToListAsync();

        public Task<Teacher> GetTeacher(Guid id) => _dbTeacher.teachers.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Teacher> UpdateTeacher(Teacher Teacher)
        {
            _dbTeacher.teachers.Update(Teacher);
            return Task.FromResult(Teacher);
        }
    }
}