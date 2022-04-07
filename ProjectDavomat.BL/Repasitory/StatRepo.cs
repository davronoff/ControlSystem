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
    public class StatRepo : IStatInterface
    {
        private readonly AppDbContext _dbContext;

        public StatRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AllStatisticViewModel GetAllStatistics()
        {
            AllStatisticViewModel viewModel = new AllStatisticViewModel()
            {
                Services = _dbContext.services.ToList().Count,
                Courses = _dbContext.courses.ToList().Count,
                Leaders = _dbContext.leaders.ToList().Count,
                Staffs = _dbContext.staffs.ToList().Count,
                Teachers = _dbContext.teachers.ToList().Count
            };

            return viewModel;
        }
    }
}
