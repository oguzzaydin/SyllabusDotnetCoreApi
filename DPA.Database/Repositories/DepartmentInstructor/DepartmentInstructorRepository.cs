using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class DepartmentInstructorRepository : EntityFrameworkCoreRepository<DepartmentInstructorEntity>, IDepartmentInstructorRepository
    {
        public DepartmentInstructorRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
