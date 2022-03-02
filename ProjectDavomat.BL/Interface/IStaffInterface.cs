using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
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

        Task<int> CountStaffs();
        Task<List<Staff>> GetRandomStaff3();

    }
}