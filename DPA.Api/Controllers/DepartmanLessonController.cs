using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api.Controllers
{
    // [Authorize(Roles = "Administrator, Admin")]
    [ApiController]
    [RouteController]
    public class DepartmentLessonController : ControllerBase
    {
        public DepartmentLessonController(IDepartmentLessonService departmentLessonService)
        {
            DepartmentLessonService = departmentLessonService;
        }

        private IDepartmentLessonService DepartmentLessonService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmentLessonModel addDepartmentLessonModel)
        {
            var result = await DepartmentLessonService.AddAsync(addDepartmentLessonModel);

            return new ActionIResult(result);
        }

        [HttpGet("{DepartmentId}/lessons")]
        public async Task<IEnumerable<ListLessonModel>> ListLessonAsync(long DepartmentId)
        {
            return await DepartmentLessonService.ListLessonAsync(DepartmentId);
        }

        [HttpGet("{lessonId}/Departments")]
        public async Task<IEnumerable<ListDepartmentModel>> ListDepartmentAsync(long lessonId)
        {
            return await DepartmentLessonService.ListDepartmentAsync(lessonId);
        }

        [HttpDelete("{DepartmentId}/Department/{lessonId}/lesson")]
        public async Task<ActionIResult> DeleteLesssonAsync(long DepartmentId, long lessonId)
        {
            var result = await DepartmentLessonService.DeleteLessonAsync(DepartmentId, lessonId);

            return new ActionIResult(result);
        }

        [HttpPut("{lessonId}/lesson")]
        public async Task<IActionResult> UpdateLessonAsync(long lessonId, UpdateDepartmentLessonModel updateDepartmentLessonModel)
        {
            var result = await DepartmentLessonService.UpdateLessonAsync(lessonId, updateDepartmentLessonModel);

            return new ActionIResult(result);
        }

        [HttpPut("{DepartmentId}/Department")]
        public async Task<IActionResult> UpdateDepartmentAsync(long DepartmentId, UpdateDepartmentLessonModel updateDepartmentLessonModel)
        {
            var result = await DepartmentLessonService.UpdateDepartmentAsync(DepartmentId, updateDepartmentLessonModel);

            return new ActionIResult(result);
        }
    }
}