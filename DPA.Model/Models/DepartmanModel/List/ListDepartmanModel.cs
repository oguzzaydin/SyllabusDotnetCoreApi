namespace DPA.Model
{
    public class ListDepartmentModel : DepartmentModel
    {
        public long DepartmentId { get; set; }

        public long? UserId { get; set; } = null;

        //public virtual ListUserModel User { get; set; }

        //public FacultyModel Faculty { get; set; }
    }
}