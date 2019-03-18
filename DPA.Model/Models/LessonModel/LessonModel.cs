namespace DPA.Model
{
    public class LessonModel
    {
        public string Name { get; set; }

        public string LessonCode { get; set; }

        public string Group { get; set; }

        public AKTS AKTS { get; set; }

        public WeeklyHour WeeklyHour { get; set; }

        public LessonType LessonType { get; set; }

        public EducationType EducationType { get; set; }
    }
}