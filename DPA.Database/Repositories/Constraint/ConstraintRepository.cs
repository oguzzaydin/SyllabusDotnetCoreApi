using DotNetCore.EntityFrameworkCore;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public sealed class ConstraintRepository : EntityFrameworkCoreRepository<ConstraintEntity>, IConstraintRepository
    {
        public ConstraintRepository(DatabaseContext context) : base(context)
        {
        }
    }
}