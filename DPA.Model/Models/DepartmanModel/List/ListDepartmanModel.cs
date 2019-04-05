namespace DPA.Model
{
    public class ListDepartmanModel : DepartmanModel
    {
        public long DepartmanId { get; set; }

        public long? UserId { get; set; } = null;

        //public virtual ListUserModel User { get; set; }

        //public FacultyModel Faculty { get; set; }
    }
}