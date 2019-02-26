namespace DPA.Model
{
    public class ConstraintEntity : BaseEntity
    {
        public long ConstraintId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFreeDay { get; set; }

        public bool IsActive { get; set; }

        public WeeklyHour WeeklyHour { get; set; }

        public EducationType EducationType { get; set; }

        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}