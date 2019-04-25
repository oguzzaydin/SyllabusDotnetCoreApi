using DPA.Model;

namespace DPA.Domain.LessonGroup
{
    public static class LessonGroupDomainFactory
    {
        public static LessonGroupDomain Create(LessonGroupType groupType, long lessonId)
        {
            return new LessonGroupDomain(
                groupType,
                lessonId
            );
        }
    }
}