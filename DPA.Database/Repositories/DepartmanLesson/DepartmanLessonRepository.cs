using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class DepartmanLessonRepository : EntityFrameworkCoreRepository<DepartmanLessonEntity>, IDepartmanLessonRepository
    {
        public DepartmanLessonRepository(DatabaseContext context) : base(context)
        {
        }
    }
}