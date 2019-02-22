using System.Collections.Generic;

namespace DPA.Model.Entities
{
    public class DepartmanEntity: BaseEntity
    {
        public string Title { get; set; }

        public string DepartmanCode { get; set; }

        public long FacultyId { get; set; }

        public virtual FacultyEntity Faculty { get; set; }

        public virtual ICollection<DepartmanLessonEntity> DepartmanLessons { get; set; } = new HashSet<DepartmanLessonEntity>();
    }
}