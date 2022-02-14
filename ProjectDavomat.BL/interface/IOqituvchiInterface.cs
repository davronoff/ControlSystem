using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pojectdavomat.BL
{
    public interface IOqituvchiInterface
    {
        Task<List<Oqituvchi>> GetAllOqituvchi();
        Task<Oqituvchi> GetOqituvchi(Guid id);
        Task<Oqituvchi> AddOqituvchi(Oqituvchi newTeacher);
        Task<Oqituvchi> UpdateOqituvchi(Oqituvchi Teacher);
        Task DeleteOqituvchi(Guid id);
    } 
}