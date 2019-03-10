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

        Task<IEnumerable<ListLocationModel>> ListAsync();

        Task<PagedList<ListLocationModel>> ListAsync(PagedListParameters parameters);

        Task<IEnumerable<ListLocationModel>> ListLocationsAsync(long facultyId);

        Task<IResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel);

        Task<ListLocationModel> SelectAsync(long locationId);
    }
}