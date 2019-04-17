using System.Collections.Generic;
using System.Linq;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Mapping;
using DPA.Database.Exceptions;
using DPA.Model;
using DPA.Model.Models.LocationModel.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DPA.Database
{
    public sealed class LocationRepository : EntityFrameworkCoreRepository<LocationEntity>, ILocationRepository
    {
        public LocationRepository(DatabaseContext context) : base(context)
        {
        }

        public List<SyllabusForLocationListDto> GetFacultyLocations(long facultyId)
        {
            var locations = Queryable.FromSql($@"SELECT * FROM Faculty.Location WHERE FacultyId = {facultyId}")
                                    .ToList();
            
            if (locations.Count == 0)
                throw new UserFriendlyException($"{facultyId} Id li fakülteye ait derslik bulunamadı.");
            
            return locations.Map<List<SyllabusForLocationListDto>>();
        }
    }
}