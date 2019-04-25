using System.Collections.Generic;

namespace DPA.Model
{
    public class ListLessonModel : LessonModel
    {
        public long LessonId { get; set; }
        public List<LessonGroups> LessonGroups { get; set; } = new List<LessonGroups>();
    }

    public class LessonGroups
    {
        public long LessonGroupId { get; set; }
        public LessonGroupType GroupType { get; set; }
    }
}