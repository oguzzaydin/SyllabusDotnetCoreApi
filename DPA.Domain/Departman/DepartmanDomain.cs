using System;
using DPA.Model;

namespace DPA.Domain
{
    public class DepartmanDomain
    {
        protected internal DepartmanDomain(string title, string departmanCode, long facultyId)
        {
            Title = title;
            DepartmanCode = departmanCode;
            FacultyId = facultyId;
        }

        protected internal DepartmanDomain
        (
            long id,
            string title,
            string departmanCode,
            long facultyId)
        {
            Id = id;
            Title = title;
            DepartmanCode = departmanCode;
            FacultyId = facultyId;
        }

        public long Id { get; private set; }

        public string Title { get; private set; }

        public string DepartmanCode { get; private set; }

        public long FacultyId { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Add()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateDepartmanModel updateDepartmanModel)
        {
            Title = updateDepartmanModel.Title;
            DepartmanCode = updateDepartmanModel.DepartmanCode;
            FacultyId = updateDepartmanModel.FacultyId;
            UpdatedDate = DateTime.Now;
        }
    }
}