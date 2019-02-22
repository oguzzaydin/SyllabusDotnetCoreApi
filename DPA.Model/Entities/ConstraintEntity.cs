using DPA.Model.Enums;

namespace DPA.Model.Entities
{
    public class ConstraintEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFreeDay { get; set; }

        public bool IsActive { get; set; }

        public int WeeklyHour { get; set; }

        public EducationType EducationType { get; set; }


        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}