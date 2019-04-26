using Newtonsoft.Json;

namespace DPA.Model
{
    public class ConstraintEntity : BaseEntity
    {
        public long ConstraintId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsFreeDay { get; set; }
        public bool IsActive { get; set; }
        // TODO : Haftalık zorunlu verilmesi gereken ders saati React da validan olarak kontrol edilmeli veya Combo ile
        public int WeeklyHour { get; set; } 
        public EducationType EducationType { get; set; }
        public long UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}