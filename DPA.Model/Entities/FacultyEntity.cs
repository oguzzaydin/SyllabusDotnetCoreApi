using System.Collections.Generic;

namespace DPA.Model
{
    public class FacultyEntity: BaseEntity
    {
        public long FacultyId { get; set; }
        
        public string Title { get; set; }

        public string FacultyCode { get; set; }

        public virtual ICollection<LocationEntity> Locations { get; set; } = new HashSet<LocationEntity>();

        public virtual ICollection<DepartmanEntity> Departmans { get; set; } = new HashSet<DepartmanEntity>();
    }
}