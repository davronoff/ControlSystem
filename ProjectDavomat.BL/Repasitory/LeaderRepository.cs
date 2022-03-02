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
    public class LeaderRepository : ILeaderInterface
    {
        private readonly AppDbContext _dbContext;

        public LeaderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Leader> AddLeader(Leader leader)
        {
            _dbContext.leaders.AddAsync(leader);
            _dbContext.SaveChanges();
            return Task.FromResult(leader);
        }

        public Task DeleteLeader(Guid id)
        {
            _dbContext.leaders.Remove(_dbContext.leaders.FirstOrDefault(x => x.Id == id));
            _dbContext.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Leader>> GetAllLeader()
        {
            return _dbContext.leaders.ToListAsync();
        }

        public Task<Leader> GetLeader(Guid id)
        {
            return _dbContext.leaders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Leader> UpdateLeader(Leader leader)
        {
            _dbContext.leaders.Update(leader);
            _dbContext.SaveChanges();
            return Task.FromResult(leader);
        }
    }
}
