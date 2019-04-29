using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api
{
    // [Authorize(Roles = "Administrator, Admin")]
    [ApiController]
    [RouteController]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController(IDepartmentService departmentService)
        {
            DepartmentService = departmentService;
        }

        private IDepartmentService DepartmentService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmentModel addDepartmentModel)
        {
            var result = await DepartmentService.AddAsync(addDepartmentModel);

            return new ActionIResult(result);
        }

        [HttpGet("{DepartmentId}/user")]
        public async Task<UserModel> SingleOrDefaultUserAsync(long DepartmentId)
        {
            return await DepartmentService.SingleOrDefaultUserAsync(DepartmentId);
        }
        [HttpGet("{DepartmentId}/syllabus")]
        public async Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long DepartmentId)
        {
            return await DepartmentService.SingleOrDefaultSyllabusAsync(DepartmentId);
        }

        [HttpGet("getDepartmentForHeadOfDepartment/{userId}")]
        public async Task<ListDepartmentModel> GetDepartmentForHeadOfDepartmentAsync(long userId)
        {
            return await DepartmentService.GetDepartmentForHeadOfDepartmentAsync(userId);
        }

        [HttpGet]
        public async Task<IEnumerable<ListDepartmentModel>> ListAsync()
        {
            return await DepartmentService.ListAsync();
        }

        [HttpPut("{DepartmentId}")]
        public async Task<IActionResult> UpdateAsync(long DepartmentId, UpdateDepartmentModel updateDepartmentModel)
        {
            var result = await DepartmentService.UpdateAsync(DepartmentId, updateDepartmentModel);

            return new ActionIResult(result);
        }
        [HttpPut("{departmentId}/firstActiveSyllabus/{firstSyllabusId}")]
        public async Task<IActionResult> UpdateFirstSyylabusAsync(long departmentId, long firstSyllabusId)
        {
            var result = await DepartmentService.UpdateFirstSyylabusAsync(departmentId, firstSyllabusId);
            return new ActionIResult(result);
        }
        [HttpPut("{departmentId}/secondActiveSyllabus/{secondSyllabusId}")]
        public async Task<IActionResult> UpdateSecondSyylabusAsync(long departmentId, long secondSyllabusId)
        {
            var result = await DepartmentService.UpdateSecondSyylabusAsync(departmentId, secondSyllabusId);
            return new ActionIResult(result);
        }
        [HttpPut("{DepartmentId}/user/{userId}")]
        public async Task<IActionResult> UpdateUserAsync(long DepartmentId, long userId)
        {
            var result = await DepartmentService.UpdateUserAsync(DepartmentId, userId);

            return new ActionIResult(result);
        }
        [HttpDelete("{DepartmentId}")]
        public async Task<IActionResult> DeleteAsync(long DepartmentId)
        {
            var result = await DepartmentService.DeleteAsync(DepartmentId);

            return new ActionIResult(result);
        }
        [HttpGet("{DepartmentId}")]
        public async Task<DepartmentModel> SelectAsync(long DepartmentId)
        {
            return await DepartmentService.SelectAsync(DepartmentId);
        }
    }
}