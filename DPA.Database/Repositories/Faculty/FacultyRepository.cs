using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class FacultyRepository : EntityFrameworkCoreRepository<FacultyEntity>, IFacultyRepository
    {
        public FacultyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}