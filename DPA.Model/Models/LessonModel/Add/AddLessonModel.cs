using System.Collections.Generic;

namespace DPA.Model
{
    public class AddLessonModel : LessonModel
    {
        public List<LessonGroupType> LessonGroupTypes { get; set; } = new List<LessonGroupType>();

    }
}