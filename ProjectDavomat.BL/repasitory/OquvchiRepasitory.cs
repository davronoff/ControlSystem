using Microsoft.EntityFrameworkCore;
using Pojectdavomat.BL;
using ProjectDavomat.Data;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDavomat.BL
{
    public class OquvchiRepasitory : IOquvchiInterface
    {
        private readonly AppDbContext _dbStudent;

        public OquvchiRepasitory(AppDbContext dbStudent)
        {
            _dbStudent = dbStudent;
        }

        public Task<Oquvchi> AddOquvchi(Oquvchi newStudent)
        {
            _dbStudent.students.Add(newStudent);
            _dbStudent.SaveChanges();
            return Task.FromResult(newStudent);
        }

        public Task DeleteOquvchi(Guid id)
        {
            Oquvchi student = _dbStudent.students.FirstOrDefault(p => p.Id == id);
            _dbStudent.students.Remove(student);
            _dbStudent.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Oquvchi>> GetAllOquvchi() => _dbStudent.students.ToListAsync();

        public Task<Oquvchi> GetOquvchi(Guid id) => _dbStudent.students.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Oquvchi> UpdateOquvchi(Oquvchi Student)
        {
            _dbStudent.students.Update(Student);
            return Task.FromResult(Student);

        }
    }
}