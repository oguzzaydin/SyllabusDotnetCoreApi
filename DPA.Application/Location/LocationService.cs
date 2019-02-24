using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;

namespace DPA.Application
{
    public sealed class LocationService : ILocationService
    {
        public Task<IDataResult<long>> AddAsync(AddLocationModel addLocationModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> DeleteAsync(long locationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<LocationModel>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedList<LocationModel>> ListAsync(PagedListParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<LocationModel> SelectAsync(long locationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel)
        {
            throw new System.NotImplementedException();
        }
    }
}