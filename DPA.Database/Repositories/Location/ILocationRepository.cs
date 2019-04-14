using System.Collections.Generic;
using DotNetCore.Repositories;
using DPA.Model;
using DPA.Model.Models.LocationModel.Dtos;

namespace DPA.Database
{
    public interface ILocationRepository : IRelationalRepository<LocationEntity>
    {
        List<SyllabusForLocationListDto> GetFacultyLocations(long facultyId);
    }
}