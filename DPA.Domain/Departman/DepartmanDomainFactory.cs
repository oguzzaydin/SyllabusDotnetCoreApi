using DPA.Model;

namespace DPA.Domain
{
    public static class DepartmanDomainFactory
    {
        public static DepartmanDomain Create(AddDepartmanModel addDepartmanModel)
        {
            return new DepartmanDomain(
                addDepartmanModel.Title,
                addDepartmanModel.DepartmanCode,
                addDepartmanModel.FacultyId
            );
        }

        public static DepartmanDomain Create(UpdateDepartmanModel updateDepartmanModel)
        {
            return new DepartmanDomain(
                updateDepartmanModel.Title,
                updateDepartmanModel.DepartmanCode,
                updateDepartmanModel.FacultyId
            );
        }

        public static DepartmanDomain Create(DepartmanEntity departmanEntity)
        {
            return new DepartmanDomain(
                departmanEntity.DepartmanId,
                departmanEntity.Title,
                departmanEntity.DepartmanCode,
                departmanEntity.FacultyId
            );
        }
    }
}