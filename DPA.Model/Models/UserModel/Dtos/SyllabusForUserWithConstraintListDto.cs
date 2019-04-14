using System.Collections.Generic;

namespace DPA.Model.Models.UserModel.Dtos
{
    public class SyllabusForUserWithConstraintListDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Roles { get; set; }
        public Status Status { get; set; }
        public Title Title { get; set; }

        public List<ConstraintDto> Constraints { get; set; }
    }

    public class ConstraintDto 
    {
        public long ConstraintId { get; set; }
        public bool IsFreeDay { get; set; }
        public bool IsActive { get; set; }
        public int WeeklyHour { get; set; } 
        public EducationType EducationType { get; set; }
        public long UserId { get; set; }
    }
}