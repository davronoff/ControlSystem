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
    public class StaffRepasitory : IStaffInterface
    {
        private readonly AppDbContext _dbStaff;

        public StaffRepasitory(AppDbContext dbStaff)
        {
            _dbStaff = dbStaff;
        }
        public Task<Staff> AddStaff(Staff newStaff)
        {
            _dbStaff.staffs.Add(newStaff);
            _dbStaff.SaveChanges();
            return Task.FromResult(newStaff);
        }

        public Task DeleteStaff(Guid id)
        {
            Staff staff = _dbStaff.staffs.FirstOrDefault(p => p.Id == id);
            _dbStaff.Remove(staff);
            _dbStaff.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Staff>> GetAllStaff() => _dbStaff.staffs.ToListAsync();

        public Task<Staff> GetStaff(Guid id) => _dbStaff.staffs.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Staff> UpdateStaff(Staff Staff)
        {
            _dbStaff.staffs.Update(Staff);
            _dbStaff.SaveChanges();
            return Task.FromResult(Staff);
        }

        //get count of staffs
        public Task<int> CountStaffs()
        {
            return Task.FromResult(_dbStaff.staffs.Count());
        }

        //get random 3 staffs
        public Task<List<Staff>> GetRandomStaff3()
        {
            if (_dbStaff.staffs.Count() <= 3)
            {
                return _dbStaff.staffs.ToListAsync();
            }
            else
            {
                return _dbStaff.staffs.Take(3).ToListAsync();
            }
        }
    }
}