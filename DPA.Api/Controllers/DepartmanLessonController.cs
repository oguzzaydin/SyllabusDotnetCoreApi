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
    public class DepartmanLessonController : ControllerBase
    {
        public DepartmanLessonController(IDepartmanLessonService departmanLessonService)
        {
            DepartmanLessonService = departmanLessonService;
        }

        private IDepartmanLessonService DepartmanLessonService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmanLessonModel addDepartmanLessonModel)
        {
            var result = await DepartmanLessonService.AddAsync(addDepartmanLessonModel);

            return new ActionIResult(result);
        }

        [HttpGet("{departmanId}/lessons")]
        public async Task<IEnumerable<LessonModel>> ListLessonAsync(long departmanId)
        {
            return await DepartmanLessonService.ListLessonAsync(departmanId);
        }

        [HttpGet("{lessonId}/departmans")]
        public async Task<IEnumerable<DepartmanModel>> ListDepartmanAsync(long lessonId)
        {
            return await DepartmanLessonService.ListDepartmanAsync(lessonId);
        }

        [HttpDelete("{departmanId}/departman/{lessonId}/lesson")]
        public async Task<ActionIResult> DeleteLesssonAsync(long departmanId, long lessonId)
        {
            var result = await DepartmanLessonService.DeleteLessonAsync(departmanId, lessonId);

            return new ActionIResult(result);
        }

        [HttpPut("{lessonId}/lesson")]
        public async Task<IActionResult> UpdateLessonAsync(long lessonId, UpdateDepartmanLessonModel updateDepartmanLessonModel)
        {
            var result = await DepartmanLessonService.UpdateLessonAsync(lessonId, updateDepartmanLessonModel);

            return new ActionIResult(result);
        }

        [HttpPut("{departmanId}/departman")]
        public async Task<IActionResult> UpdateDepartmanAsync(long departmanId, UpdateDepartmanLessonModel updateDepartmanLessonModel)
        {
            var result = await DepartmanLessonService.UpdateDepartmanAsync(departmanId, updateDepartmanLessonModel);

            return new ActionIResult(result);
        }
    }
}