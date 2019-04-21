using System;
using System.Collections.Generic;

namespace DPA.Model.Models.SyllabusModel.Dtos
{
    public class SyllabusForLessonWithGroupListDto
    {
        public long LessonId { get; set; }
        public string Name { get; set; }
        public string LessonCode { get; set; }
        public int AKTS { get; set; }
        public int Credit { get; set; }
        public int WeeklyHour { get; set; }
        public SemesterType SemesterType { get; set; }
        public LessonType LessonType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<LessonGroupDto> LessonGroups { get; set; }
    }

    public class LessonGroupDto
    {
        public long? LessonGroupId { get; set; }
        public long LessonId { get; set; }
        public LessonGroupType GroupType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}