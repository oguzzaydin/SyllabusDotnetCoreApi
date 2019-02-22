using System.Collections.Generic;

namespace DPA.Model.Entities
{
    public class LocationEntity: BaseEntity
    {
        public string Title { get; set; }

        public long FacultyId { get; set; }

        public virtual FacultyEntity Faculty { get; set; }

        public virtual ICollection<UnitLessonEntity> UnitLessons { get; set; } = new HashSet<UnitLessonEntity>();

    }
}