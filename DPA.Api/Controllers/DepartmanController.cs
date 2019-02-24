using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api
{
    [ApiController]
    [RouteController]
    public class DepartmanController : ControllerBase
    {
        public DepartmanController(IDepartmanService departmanService)
        {
            DepartmanService = departmanService;
        }

        private IDepartmanService DepartmanService { get; }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AddDepartmanModel addDepartmanModel)
        {
            var result = await DepartmanService.AddAsync(addDepartmanModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmanModel>> ListAsync()
        {
            return await DepartmanService.ListAsync();
        }

        [HttpPut("{departmanId}")]
        public async Task<IActionResult> UpdateAsync(long departmanId, UpdateDepartmanModel updateDepartmanModel)
        {
            var result = await DepartmanService.UpdateAsync(departmanId, updateDepartmanModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{departmanId}")]
        public async Task<IActionResult> DeleteAsync(long departmanId)
        {
            var result = await DepartmanService.DeleteAsync(departmanId);

            return new ActionIResult(result);
        }

        [HttpGet("{departmanId}")]
        public async Task<DepartmanModel> SelectAsync(long departmanId)
        {
            return await DepartmanService.SelectAsync(departmanId);
        }
    }
}