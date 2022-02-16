using ProjectDavomat.BL.Interface;
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
        public Task<Staff> AddStaff(Staff newStaff)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStaff(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Staff>> GetAllStaff()
        {
            throw new NotImplementedException();
        }

        public Task<Staff> GetStaff(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> UpdateStaff(Staff Staff)
        {
            throw new NotImplementedException();
        }
    }
}
