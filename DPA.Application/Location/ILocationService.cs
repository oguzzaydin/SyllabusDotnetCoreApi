using DotNetCore.Objects;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public interface ILocationService
    {
        Task<IDataResult<long>> AddAsync(AddLocationModel addLocationModel);

        Task<IResult> DeleteAsync(long locationId);

        Task<IEnumerable<LocationModel>> ListAsync();

        Task<PagedList<LocationModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<LocationModel>> ListLocationsAsync(long facultyId);

        Task<IResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel);

        Task<LocationModel> SelectAsync(long locationId);
    }
}