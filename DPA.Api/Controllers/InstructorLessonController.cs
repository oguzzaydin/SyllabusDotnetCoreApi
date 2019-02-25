using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api
{
    [ApiController]
    [RouteController]
    public class InstructorLessonController
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
    }
}