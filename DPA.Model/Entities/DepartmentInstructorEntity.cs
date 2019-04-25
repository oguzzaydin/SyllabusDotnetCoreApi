namespace DPA.Model
{
    public class DepartmentInstructorEntity : BaseEntity
    {
        public long DepartmentInstructorId { get; set; }
        public long UserId { get; set; }
        public long DepartmentId { get; set; }
        public virtual DepartmentEntity Department { get; set; }
        public virtual UserEntity User { get; set; }
    }
}