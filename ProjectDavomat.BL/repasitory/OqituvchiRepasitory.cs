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
    public class OqituvchiRepasitory : IOqituvchiInterface
    {
        private readonly AppDbContext _dbTeacher;

        public OqituvchiRepasitory(AppDbContext dbTeacher)
        {
            _dbTeacher = dbTeacher;
        }
        public Task<Oqituvchi> AddOqituvchi(Oqituvchi newTeacher)
        {
            _dbTeacher.teachers.Add(newTeacher);
            _dbTeacher.SaveChanges();
            return Task.FromResult(newTeacher);
        }

        public Task DeleteOqituvchi(Guid id)
        {
            Oqituvchi teacher = _dbTeacher.teachers.FirstOrDefault(p => p.Id == id);
            _dbTeacher.teachers.Remove(teacher);
            _dbTeacher.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Oqituvchi>> GetAllOqituvchi() => _dbTeacher.teachers.ToListAsync();

        public Task<Oqituvchi> GetOqituvchi(Guid id) => _dbTeacher.teachers.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Oqituvchi> UpdateOqituvchi(Oqituvchi Teacher)
        {
            _dbTeacher.teachers.Update(Teacher);
            return Task.FromResult(Teacher);
        }
    }
}