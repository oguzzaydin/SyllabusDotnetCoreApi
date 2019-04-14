using System.Collections.Generic;
using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database.Repositories.LessonGroup
{
    public sealed class LessonGroupRepository : EntityFrameworkCoreRepository<LessonGroupEntity>, ILessonGroupRepository
    {
        public LessonGroupRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<LessonGroupEntity> GetLessonGroups(long lessonId)
        {
            return List(x => x.LessonId == lessonId);
        }
    }
}