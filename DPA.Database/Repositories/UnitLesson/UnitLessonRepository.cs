using DotNetCore.EntityFrameworkCore;
using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database.Repositories.UnitLesson
{
    public class UnitLessonRepository : EntityFrameworkCoreRepository<UnitLessonEntity>, IUnitLessonRepository
    {
        public UnitLessonRepository(DatabaseContext context) : base(context)
        {
        }
    }
}