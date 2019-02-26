using DPA.Model;
using System;

namespace DPA.Domain
{
    public class LocationDomain
    {
        protected internal LocationDomain(string title, long facultyId)
        {
            Title = title;
            FacultyId = facultyId;
        }

        protected internal LocationDomain(long id, string title, long facultyId)
        {
            Id = id;
            Title = title;
            FacultyId = facultyId;
        }

        public long Id { get; private set; }

        public string Title { get; private set; }

        public long FacultyId { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Add()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateLocationModel updateLocationModel)
        {
            Title = updateLocationModel.Title;
            FacultyId = updateLocationModel.FacultyId;
            UpdatedDate = DateTime.Now;
        }
    }
}