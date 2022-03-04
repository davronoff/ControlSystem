using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface IServiceInterface
    {
        Task<List<Service>> GetAllService();
        Task<Service> GetService(Guid id);
        Task<Service> AddService(Service newService);
        Task<Service> UpdateService(Service Service);
        Task DeleteService(Guid id);
        Task<int> CountService();
        Task<List<Service>> GetRandomService3();
    }
}