using DotNetCore.EntityFrameworkCore;
using DPA.Model;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public class SyllabusRepository : EntityFrameworkCoreRepository<SyllabusEntity>, ISyllabusRepository
    {
        public SyllabusRepository(DatabaseContext context) : base(context)
        {
        }
    }
}