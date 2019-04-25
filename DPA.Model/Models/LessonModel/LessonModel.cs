using System.Collections.Generic;

namespace DPA.Model
{
    public class LessonModel
    {
        public string Name { get; set; }
        public string LessonCode { get; set; }
        public int AKTS { get; set; }
        public int WeeklyHour { get; set; }
        public LessonType LessonType { get; set; }
        public SemesterType SemesterType { get; set; }
    }
}