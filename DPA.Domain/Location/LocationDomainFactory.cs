using DPA.Model;

namespace DPA.Domain
{
    public static class LocationDomainFactory
    {
        public static LocationDomain Create(AddLocationModel addLocationModel)
        {
            return new LocationDomain(
                addLocationModel.Title,
                addLocationModel.FacultyId
            );
        }

        public static LocationDomain Create(UpdateLocationModel updateLocationModel)
        {
            return new LocationDomain(
                updateLocationModel.Title,
                updateLocationModel.FacultyId
            );
        }

        public static LocationDomain Create(LocationEntity locationEntity)
        {
            return new LocationDomain(
                locationEntity.Id,
                locationEntity.Title,
                locationEntity.FacultyId
            );
        }
    }
}