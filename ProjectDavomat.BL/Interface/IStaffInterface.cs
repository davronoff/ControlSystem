
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface IStaffInterface
    {
        Task<List<Staff>> GetAllStaff();
        Task<Staff> GetStaff(Guid id);
        Task<Staff> AddStaff(Staff newStaff);
        Task<Staff> UpdateStaff(Staff Staff);
        Task DeleteStaff(Guid id);

    }
}
