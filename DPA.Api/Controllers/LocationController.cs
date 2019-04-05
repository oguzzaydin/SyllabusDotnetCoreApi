using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
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


        /// <summary>
        /// Derslik sınıf Role = Admin   CRUD işlemleri
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddAsync(AddLocationModel addLocationModel)
        {
            var result = await LocationService.AddAsync(addLocationModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Admin, User")]
        public async Task<IEnumerable<ListLocationModel>> ListAsync()
        {
            return await LocationService.ListAsync();
        }

        [HttpGet("{facultyId}/locations")]
        [Authorize(Roles = "Administrator, Admin, User")]
        public async Task<IEnumerable<ListLocationModel>> ListLocationsAsync(long facultyId)
        {
            return await LocationService.ListLocationsAsync(facultyId).ConfigureAwait(false);
        }

        [HttpPut("{LocationId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateAsync(long locationId, UpdateLocationModel updateLocationModel)
        {
            var result = await LocationService.UpdateAsync(locationId, updateLocationModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{locationId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAsync(long locationId)
        {
            var result = await LocationService.DeleteAsync(locationId);

            return new ActionIResult(result);
        }

        [HttpGet("{locationId}")]
        [Authorize(Roles = "Administrator, Admin, User")]
        public async Task<ListLocationModel> SelectAsync(long locationId)
        {
            return await LocationService.SelectAsync(locationId);
        }
    }
}