using ProjectDavomat.BL.Interface;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Repasitory
{
    public class ServiceRepasitory : IServiceInterface
    {
        public Task<Service> AddService(Service newService)
        {
            throw new NotImplementedException();
        }

        public Task DeleteService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetAllService()
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateService(Service Service)
        {
            throw new NotImplementedException();
        }
    }
}
