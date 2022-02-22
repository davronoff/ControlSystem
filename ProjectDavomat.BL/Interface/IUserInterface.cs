using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDavomat.BL.Interface
{
    public interface IUserInterface
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUser(Guid id);
        Task<User> AddUser(User newStudent);
        Task<User> UpdateUser(User Student);
        Task DeleteUser(Guid id);
    }
}