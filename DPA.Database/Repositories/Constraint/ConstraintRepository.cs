using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class ConstraintRepository : EntityFrameworkCoreRepository<ConstraintEntity>, IConstraintRepository
    {
        public ConstraintRepository(DatabaseContext context) : base(context)
        {
        }
    }
}