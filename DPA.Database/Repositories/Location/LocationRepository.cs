using DotNetCore.EntityFrameworkCore;
using DPA.Model;

namespace DPA.Database
{
    public sealed class LocationRepository : EntityFrameworkCoreRepository<LocationEntity>, ILocationRepository
    {
        public LocationRepository(DatabaseContext context) : base(context)
        {
        }
    }
}