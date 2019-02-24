using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class LessonRepository : EntityFrameworkCoreRepository<LessonEntity>, ILessonRepository
    {
        public LessonRepository(DatabaseContext context) : base(context)
        {
        }
    }
}