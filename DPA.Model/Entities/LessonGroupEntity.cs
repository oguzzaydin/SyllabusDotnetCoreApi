using System;
using Newtonsoft.Json;

namespace DPA.Model
{
    public class LessonGroupEntity : BaseEntity
    {
        public long LessonGroupId { get; set; }
        public LessonGroupType GroupType { get; set; }
        public long LessonId { get; set; }
        public virtual LessonEntity Lesson { get; set; }
    }
}
