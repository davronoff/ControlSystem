using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pojectdavomat.BL
{
    public interface IOquvchiInterface
    {
        Task<List<Oquvchi>> GetAllOquvchi();
        Task<Oquvchi> GetOquvchi(Guid id);
        Task<Oquvchi> AddOquvchi(Oquvchi newStudent);
        Task<Oquvchi> UpdateOquvchi(Oquvchi Student);
        Task DeleteOquvchi(Guid id);
    }
}