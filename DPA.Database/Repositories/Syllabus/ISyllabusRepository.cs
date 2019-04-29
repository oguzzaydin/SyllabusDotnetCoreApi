using System.Collections.Generic;
using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database
{
    public interface ISyllabusRepository : IRelationalRepository<SyllabusEntity>
    {
        SyylabusForDepartmentDTo GetSyllabusForDepartment(long departmentId);
        SyylabusForDepartmentDTo GetFirstSyllabusForDepartment(long departmentId);
        SyylabusForDepartmentDTo GetSecondSyllabusForDepartment(long departmentId);
    }
}