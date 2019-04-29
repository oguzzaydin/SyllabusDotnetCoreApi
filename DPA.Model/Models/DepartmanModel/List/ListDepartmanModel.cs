namespace DPA.Model
{
    public class ListDepartmentModel : DepartmentModel
    {
        public long DepartmentId { get; set; }
        public long SecondActiveSyllabusId { get; set; }
        public long FirstActiveSyllabusId { get; set; }
    }
}