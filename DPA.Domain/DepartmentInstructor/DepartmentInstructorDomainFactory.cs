using DPA.Model;

namespace DPA.Domain.DepartmentInstructor
{
    public static class DepartmentInstructorDomainFactory
    {
        public static DepartmentInstructorDomain Create(DepartmentInstructorModel departmanInstructor)
        {
            return new DepartmentInstructorDomain(
                departmanInstructor.UserId,
                departmanInstructor.DepartmentId
            );
        }

        public static DepartmentInstructorDomain Create(DepartmentInstructorEntity departmentInstructorEntity)
        {
            return new DepartmentInstructorDomain(
                departmentInstructorEntity.UserId,
                departmentInstructorEntity.DepartmentId
            );
        }
    }
}