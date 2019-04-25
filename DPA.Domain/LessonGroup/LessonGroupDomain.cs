using DPA.Model;

namespace DPA.Domain.LessonGroup
{
    public class LessonGroupDomain
    {
        protected internal LessonGroupDomain(LessonGroupType groupType, long lessonId)
        {
            GroupType = groupType;
            LessonId = lessonId;
        }
        public LessonGroupType GroupType { get; set; }
        public long LessonId { get; set; }
    }
}