using System.Collections.Generic;
using System.Threading.Tasks;
using DPA.Model;

namespace DPA.Application
{
    public interface ISyllabusService
    {
        Task<SyllabusEntity> CreateSyllabus(CreateSyllabusRequest request);
        Task<SyylabusForDepartmentDTo> GetSyllabusForDepartment(long departmentId);
    }
}