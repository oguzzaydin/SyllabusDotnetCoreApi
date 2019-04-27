using System.Collections.Generic;

namespace DPA.Model.Models.UserModel.Dtos
{
    public class SyllabusForUserWithConstraintListDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public Title Title { get; set; }

        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsFreeDay { get; set; }
        public bool IsActive { get; set; }
        public int WeeklyHour { get; set; } 
        public EducationType EducationType { get; set; }

    }
}