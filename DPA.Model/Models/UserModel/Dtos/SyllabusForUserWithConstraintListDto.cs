using System.Collections.Generic;

namespace DPA.Model.Models.UserModel.Dtos
{
    public class SyllabusForUserWithConstraintListDto
    {
        public long UserId { get; set; }
        public Title Title { get; set; }
        public ConstraintDto Constraint { get; set;}

    }

    public class ConstraintDto
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsFreeDay { get; set; }
        public int WeeklyHour { get; set; }
        public EducationType EducationType { get; set; }
    }
}