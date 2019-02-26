using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api
{
    [ApiController]
    [RouteController]
    public class LocationController : ControllerBase
    {
        public LocationController(ILocationService locationService)
        {
            LocationService = locationService;
        }

        private ILocationService LocationService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddLocationModel addLocationModel)
        {
            var result = await LocationService.AddAsync(addLocationModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<LocationModel>> ListAsync()
        {
            return await LocationService.ListAsync();
        }

        [HttpPut("{LocationId}")]
        public async Task<IActionResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel)
        {
            var result = await LocationService.UpdateAsync(locationId, updateLocationModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteAsync(long locationId)
        {
            var result = await LocationService.DeleteAsync(locationId);

            return new ActionIResult(result);
        }

        [HttpGet("{locationId}")]
        public async Task<LocationModel> SelectAsync(long locationId)
        {
            return await LocationService.SelectAsync(locationId);
        }
    }
}