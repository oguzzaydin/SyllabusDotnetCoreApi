using System;
using DPA.Model;

namespace DPA.Domain.DepartmentInstructor
{
    public class DepartmentInstructorDomain
    {
        protected internal DepartmentInstructorDomain(long userId, long departmentId)
        {
            DepartmentId = departmentId;
            UserId = userId;
        }
        public long UserId { get; set; }
        public long DepartmentId { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime UpdatedDate { get; private set; } = DateTime.Now;

        public void Update(long departmentId, long userId)
        {
            DepartmentId = departmentId;
            UserId = userId;
        }

    }
}