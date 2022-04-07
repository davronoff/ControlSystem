using ProjectDavomat.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface ILeaderInterface
    {
        Task<List<Leader>> GetAllLeader();
        Task<Leader> GetLeader(Guid id);
        Task<Leader> AddLeader(Leader leader);
        Task<Leader> UpdateLeader(Leader leader);
        Task DeleteLeader(Guid id);
        int GetLeaderCount();
    }
}