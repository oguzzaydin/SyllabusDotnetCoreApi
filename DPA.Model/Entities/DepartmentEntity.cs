using System.Collections.Generic;

namespace DPA.Model
{
    public class DepartmentEntity : BaseEntity
    {
        public long DepartmentId { get; set; }

        public string Title { get; set; }

        public string DepartmentCode { get; set; }

        public long FacultyId { get; set; }

        public long? HeadOfDepartmentId { get; set; }

        public virtual UserEntity HeadOfDepartment { get; set; }

        public virtual FacultyEntity Faculty { get; set; }

        public virtual ICollection<DepartmentLessonEntity> DepartmentLessons { get; set; } = new HashSet<DepartmentLessonEntity>();
        
        public virtual ICollection<SyllabusEntity> Syllabus { get; set; } = new HashSet<SyllabusEntity>();
    }
}