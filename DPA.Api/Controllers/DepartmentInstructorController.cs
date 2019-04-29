using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application.DepartmentInstuctor;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api.Controllers
{

    [ApiController]
    [RouteController]
    public class DepartmentInstructorController : ControllerBase
    {
        private readonly IDepartmentInstuctorService _departmentInstuctorService;
        public DepartmentInstructorController(IDepartmentInstuctorService departmentInstuctorService)
        {
            _departmentInstuctorService = departmentInstuctorService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddAsync(DepartmentInstructorModel request)
        {
            var result = await _departmentInstuctorService.AddAsync(request);
            return new ActionIResult(result);
        }

        [HttpGet("{departmentId}/instructors")]
        public async Task<IEnumerable<ListUserModel>> ListInstructorAsync(long departmentId)
            => await _departmentInstuctorService.ListInstructorAsync(departmentId);

        [HttpGet("{userId}/departments")]
        public async Task<IEnumerable<ListDepartmentModel>> ListDepartmentAsync(long userId)
            => await _departmentInstuctorService.ListDepartmentAsync(userId);

        [HttpDelete("{departmentId}/instructor/{userId}")]
        public async Task<ActionIResult> DeleteInstructorAsync(long departmentId, long userId)
        {
            var result = await _departmentInstuctorService.DeleteInstructorAsync(departmentId, userId);
            return new ActionIResult(result);
        }
    }
}