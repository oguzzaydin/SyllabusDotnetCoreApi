using System.Collections.Generic;
using System.Threading.Tasks;
using DPA.Model;

namespace DPA.Application
{
    public interface ISyllabusService
    {
        Task<SyylabusForDepartmentDTo> CreateSyllabus(CreateSyllabusRequest request);
        Task<IEnumerable<SyylabusForDepartmentDTo>> GetSyllabusForDepartment(long departmentId);
        SyylabusForDepartmentDTo GetFirstSyllabusForDepartment(long departmentId);
        SyylabusForDepartmentDTo GetSecondSyllabusForDepartment(long departmentId);
    }
}