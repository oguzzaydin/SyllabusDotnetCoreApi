using System.Collections.Generic;
using DotNetCore.Repositories;
using DPA.Model;

namespace DPA.Database.Repositories.LessonGroup
{
    public interface ILessonGroupRepository : IRelationalRepository<LessonGroupEntity>
    {
        IEnumerable<LessonGroupEntity> GetLessonGroups(long lessonId);
    }
}