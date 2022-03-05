using Microsoft.EntityFrameworkCore;
using ProjectDavomat.BL.Interface;
using ProjectDavomat.Data.DataLayer;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Repasitory
{
    public class ServiceRepasitory : IServiceInterface
    {
        private readonly AppDbContext _dbService;

        public ServiceRepasitory(AppDbContext dbService)
        {
            _dbService = dbService;
        }
        public Task<Service> AddService(Service newService)
        {
            _dbService.Add(newService);
            _dbService.SaveChanges();
            return Task.FromResult(newService);
        }

        public Task DeleteService(Guid id)
        {
            Service service = _dbService.services.FirstOrDefault(p => p.Id == id);
            _dbService.services.Remove(service);
            _dbService.SaveChanges();
            return Task.FromResult(0);
        }

        public Task<List<Service>> GetAllService() => _dbService.services.ToListAsync();

        public Task<Service> GetService(Guid id) => _dbService.services.FirstOrDefaultAsync(p => p.Id == id);

        public Task<Service> UpdateService(Service Service)
        {
            _dbService.services.Update(Service);
            _dbService.SaveChanges();
            return Task.FromResult(Service);
        }

        //get count of services
        public Task<int> CountService()
        {
            return Task.FromResult(_dbService.services.Count());
        }
        
        //get random 3 courses
        public Task<List<Service>> GetRandomService3()
        {
            if (_dbService.services.Count() <= 3)
            {
                return _dbService.services.ToListAsync();
            }
            else
            {
                Random rnd = new Random();
                return _dbService.services.Take(3).ToListAsync();
            }
        }
    }
}