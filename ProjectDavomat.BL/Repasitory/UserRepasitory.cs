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
    public class UserRepasitory : IUserInterface
    {
        private readonly AppDbContext _dbStudent;

        public UserRepasitory(AppDbContext dbStudent)
        {
            _dbStudent = dbStudent;
        }

        public Task<User> AddUser(User newStudent)
        {
            _dbStudent.students.Add(newStudent);
            _dbStudent.SaveChanges();
            return Task.FromResult(newStudent);
        }

        public Task DeleteUser(Guid id)
        {
            User student = _dbStudent.students.FirstOrDefault(p => p.Id == id);
            _dbStudent.students.Remove(student);
            _dbStudent.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<User>> GetAllUser() => _dbStudent.students.ToListAsync();

        public Task<User> GetUser(Guid id) => _dbStudent.students.FirstOrDefaultAsync(p => p.Id == id);

        public Task<User> UpdateUser(User Student)
        {
            _dbStudent.students.Update(Student);
            return Task.FromResult(Student);

        }
    }
}