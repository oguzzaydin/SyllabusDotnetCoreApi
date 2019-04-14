using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class DepartmentRepository : EntityFrameworkCoreRepository<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(DatabaseContext context) : base(context)
        {
        }
    }
}