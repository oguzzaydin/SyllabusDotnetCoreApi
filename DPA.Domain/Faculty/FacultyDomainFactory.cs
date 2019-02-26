using DPA.Model;

namespace DPA.Domain
{
    public static class FacultyDomainFactory
    {
        public static FacultyDomain Create(AddFacultyModel addFacultyModel)
        {
            return new FacultyDomain(
                addFacultyModel.Title,
                addFacultyModel.FacultyCode
            );
        }

        public static FacultyDomain Create(UpdateFacultyModel updateFacultyModel)
        {
            return new FacultyDomain(
                updateFacultyModel.Title,
                updateFacultyModel.FacultyCode
            );
        }

        public static FacultyDomain Create(FacultyEntity facultyEntity)
        {
            return new FacultyDomain(
                facultyEntity.FacultyId,
                facultyEntity.Title,
                facultyEntity.FacultyCode
            );
        }
    }
}