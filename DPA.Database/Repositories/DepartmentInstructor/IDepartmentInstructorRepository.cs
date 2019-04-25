using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database
{
    public interface IDepartmentInstructorRepository : IRelationalRepository<DepartmentInstructorEntity>
    {
    }
}