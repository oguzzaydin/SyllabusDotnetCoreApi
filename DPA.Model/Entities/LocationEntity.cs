using System.Collections.Generic;

namespace DPA.Model
{
    public class LocationEntity : BaseEntity
    {
        public long LocationId { get; set; }
        public string Title { get; set; }
        public long FacultyId { get; set; }
        public virtual FacultyEntity Faculty { get; set; }
        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();
    }
}