using DPA.Model;

namespace DPA.Domain
{
    public static class DepartmentDomainFactory
    {
        public static DepartmentDomain Create(AddDepartmentModel addDepartmentModel)
        {
            return new DepartmentDomain(
                addDepartmentModel.Title,
                addDepartmentModel.DepartmentCode,
                addDepartmentModel.FacultyId
            );
        }

        public static DepartmentDomain Create(UpdateDepartmentModel updateDepartmentModel)
        {
            return new DepartmentDomain(
                updateDepartmentModel.Title,
                updateDepartmentModel.DepartmentCode,
                updateDepartmentModel.FacultyId
            );
        }

        public static DepartmentDomain Create(DepartmentEntity DepartmentEntity)
        {
            return new DepartmentDomain(
                DepartmentEntity.DepartmentId,
                DepartmentEntity.Title,
                DepartmentEntity.DepartmentCode,
                DepartmentEntity.FacultyId
            );
        }
    }
}