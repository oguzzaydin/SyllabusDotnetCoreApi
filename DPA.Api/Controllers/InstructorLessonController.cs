using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api
{
    [Authorize(Roles = "Administrator, Admin")]
    [ApiController]
    [RouteController]
    public class InstructorLessonController : ControllerBase
    {
        public InstructorLessonController(IUserLessonService userLessonService)
        {
            UserLessonService = userLessonService;
        }

        private IUserLessonService UserLessonService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddUserLessonModel addUserLessonModel)
        {
            var result = await UserLessonService.AddAsync(addUserLessonModel);

            return new ActionIResult(result);
        }

        [HttpGet("{userId}/lessons")]
        public async Task<IEnumerable<ListLessonModel>> ListLessonAsync(long userId)
        {
            return await UserLessonService.ListLessonAsync(userId);
        }

        [HttpGet("{lessonId}/instuctors")]
        public async Task<IEnumerable<ListUserModel>> ListInstructorAsync(long lessonId)
        {
            return await UserLessonService.ListInstructorAsync(lessonId);
        }

        [HttpDelete("{userId}/instructor/{lessonId}/lesson")]
        public async Task<ActionIResult> DeleteLesssonAsync(long userId, long lessonId)
        {
            var result = await UserLessonService.DeleteLessonAsync(userId, lessonId);

            return new ActionIResult(result);
        }

        [HttpPut("{lessonId}/lesson")]
        public async Task<IActionResult> UpdateLessonAsync(long lessonId, UpdateUserLessonModel updateUserLessonModel)
        {
            var result = await UserLessonService.UpdateLessonAsync(lessonId, updateUserLessonModel);

            return new ActionIResult(result);
        }

        [HttpPut("{userId}/instructor")]
        public async Task<IActionResult> UpdateDepartmanAsync(long userId, UpdateUserLessonModel updateUserLessonModel)
        {
            var result = await UserLessonService.UpdateInstructorAsync(userId, updateUserLessonModel);

            return new ActionIResult(result);
        }
    }
}