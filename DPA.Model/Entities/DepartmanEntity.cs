using System.Collections.Generic;

namespace DPA.Model
{
    public class DepartmanEntity : BaseEntity
    {
        public long DepartmanId { get; set; }

        public string Title { get; set; }

        public string DepartmanCode { get; set; }

        public long FacultyId { get; set; }

        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual FacultyEntity Faculty { get; set; }

        public virtual ICollection<DepartmanLessonEntity> DepartmanLessons { get; set; } = new HashSet<DepartmanLessonEntity>();
        
        public virtual ICollection<SyllabusEntity> Syllabus { get; set; } = new HashSet<SyllabusEntity>();
    }
}