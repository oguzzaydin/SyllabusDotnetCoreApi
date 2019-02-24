using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class DepartmanRepository : EntityFrameworkCoreRepository<DepartmanEntity>, IDepartmanRepository
    {
        public DepartmanRepository(DatabaseContext context) : base(context)
        {
        }
    }
}