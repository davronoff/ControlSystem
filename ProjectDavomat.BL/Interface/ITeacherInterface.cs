using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pojectdavomat.BL
{
    public interface ITeacherInterface
    {
        Task<List<Teacher>> GetAllTeacher();
        Task<Teacher> GetTeacher(Guid id);
        Task<Teacher> AddTeacher(Teacher newTeacher);
        Task<Teacher> UpdateTeacher(Teacher Teacher);
        Task DeleteTeacher(Guid id);
    }
}