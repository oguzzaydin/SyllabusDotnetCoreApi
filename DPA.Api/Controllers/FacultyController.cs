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
    public class FacultyController : ControllerBase
    {
        public FacultyController(IFacultyService facultyService)
        {
            FacultyService = facultyService;
        }

        private IFacultyService FacultyService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddFacultyModel addFacultyModel)
        {
            var result = await FacultyService.AddAsync(addFacultyModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<FacultyModel>> ListAsync()
        {
            return await FacultyService.ListAsync();
        }

     

        [HttpPut("{facultyId}")]
        public async Task<IActionResult> UpdateAsync(long facultyId, UpdateFacultyModel updateFacultyModel)
        {
            var result = await FacultyService.UpdateAsync(facultyId, updateFacultyModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> DeleteAsync(long facultyId)
        {
            var result = await FacultyService.DeleteAsync(facultyId);

            return new ActionIResult(result);
        }

        [HttpGet("{facultyId}")]
        public async Task<FacultyModel> SelectAsync(long facultyId)
        {
            return await FacultyService.SelectAsync(facultyId);
        }
    }
}