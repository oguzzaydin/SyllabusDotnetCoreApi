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
    public class FacultyController : ControllerBase
    {
        public FacultyController(IFacultyService facultyService)
        {
            FacultyService = facultyService;
        }

        private IFacultyService FacultyService { get; }


        /// <summary>
        /// Fakülte Role = Administrator  CRUD işlemleri
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> AddAsync(AddFacultyModel addFacultyModel)
        {
            var result = await FacultyService.AddAsync(addFacultyModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Admin, User")]
        public async Task<IEnumerable<ListFacultyModel>> ListAsync()
        {
            return await FacultyService.ListAsync();
        }

     

        [HttpPut("{facultyId}")]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> UpdateAsync(long facultyId, UpdateFacultyModel updateFacultyModel)
        {
            var result = await FacultyService.UpdateAsync(facultyId, updateFacultyModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{facultyId}")]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeleteAsync(long facultyId)
        {
            var result = await FacultyService.DeleteAsync(facultyId);

            return new ActionIResult(result);
        }

        [HttpGet("{facultyId}")]
        [Authorize(Roles = "Administrator, Admin, User")]
        public async Task<ListFacultyModel> SelectAsync(long facultyId)
        {
            return await FacultyService.SelectAsync(facultyId);
        }
    }
}