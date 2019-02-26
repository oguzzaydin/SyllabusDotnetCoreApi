using DPA.Model;
using System;

namespace DPA.Domain
{
    public class FacultyDomain
    {
        protected internal FacultyDomain(string title, string facultyCode)
        {
            Title = title;
            FacultyCode = facultyCode;
        }

        protected internal FacultyDomain(long id, string title, string facultyCode)
        {
            Id = id;
            Title = title;
            FacultyCode = facultyCode;
        }

        public long Id { get; private set; }

        public string Title { get; private set; }

        public string FacultyCode { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public void Add()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateFacultyModel updateFacultyModel)
        {
            Title = updateFacultyModel.Title;
            FacultyCode = updateFacultyModel.FacultyCode;
            UpdatedDate = DateTime.Now;
        }
    }
}