using DPA.Model;
using System;

namespace DPA.Domain
{
    public class DepartmentDomain
    {
        protected internal DepartmentDomain(string title, string departmentCode, long facultyId)
        {
            Title = title;
            DepartmentCode = departmentCode;
            FacultyId = facultyId;
        }

        protected internal DepartmentDomain
        (
            long id,
            string title,
            string departmentCode,
            long facultyId
        )
        {
            Id = id;
            Title = title;
            DepartmentCode = departmentCode;
            FacultyId = facultyId;
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string DepartmentCode { get; private set; }
        public long FacultyId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }

        public void Add()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateDepartmentModel updateDepartmentModel)
        {
            Title = updateDepartmentModel.Title;
            DepartmentCode = updateDepartmentModel.DepartmentCode;
            FacultyId = updateDepartmentModel.FacultyId;
            UpdatedDate = DateTime.Now;
        }

        public void Update(DepartmentEntity DepartmentEntity)
        {
            Title = DepartmentEntity.Title;
            DepartmentCode = DepartmentEntity.DepartmentCode;
            FacultyId = DepartmentEntity.FacultyId;
            UpdatedDate = DateTime.Now;
        }


    }
}