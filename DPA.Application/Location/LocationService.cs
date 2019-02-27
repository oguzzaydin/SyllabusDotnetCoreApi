using DotNetCore.Mapping;
using DotNetCore.Objects;
using DPA.Database;
using DPA.Domain;
using DPA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Application
{
    public sealed class LocationService : ILocationService
    {
        public LocationService(
            IDatabaseUnitOfWork databaseUnitOfWork,
            ILocationRepository locationRepository
        )
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            LocationRepository = locationRepository;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        private ILocationRepository LocationRepository { get; }

        public async Task<IDataResult<long>> AddAsync(AddLocationModel addLocationModel)
        {
            var validation = new LocationModelValidator().Valid(addLocationModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var locationDomain = LocationDomainFactory.Create(addLocationModel);

            locationDomain.Add();

            var locationEntity = locationDomain.Map<LocationEntity>();

            await LocationRepository.AddAsync(locationEntity);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessDataResult<long>(locationEntity.LocationId);
        }

        public async Task<IResult> DeleteAsync(long locationId)
        {
            await LocationRepository.DeleteAsync(locationId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IEnumerable<LocationModel>> ListAsync()
        {
            return await LocationRepository.ListAsync<LocationModel>();
        }

        public async Task<PagedList<LocationModel>> ListAsync(PagedListParameters parameters)
        {
            return await LocationRepository.ListAsync<LocationModel>(parameters);
        }

        public async Task<IEnumerable<LocationModel>> ListLocationsAsync(long facultyId)
        {
            return await LocationRepository.ListAsync<LocationModel>(x => x.FacultyId == facultyId);
        }

        public async Task<LocationModel> SelectAsync(long locationId)
        {
            return await LocationRepository.SelectAsync<LocationModel>(locationId);
        }

        public async Task<IResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel)
        {
            var validation = new LocationModelValidator().Valid(updateLocationModel);

            if (!validation.Success)
            {
                return new ErrorDataResult<long>(validation.Message);
            }

            var locationEntity = await LocationRepository.SelectAsync(locationId);

            var locationDomain = LocationDomainFactory.Create(locationEntity);

            locationDomain.Update(updateLocationModel);

            locationEntity = locationDomain.Map<LocationEntity>();

            await LocationRepository.UpdateAsync(locationEntity, locationEntity.LocationId);

            await DatabaseUnitOfWork.SaveChangesAsync();

            return new SuccessResult();
        }
    }
}