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
    public class LessonController : ControllerBase
    {
        public LessonController(ILessonService lessonService)
        {
            LessonService = lessonService;
        }

        private ILessonService LessonService { get; }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AddLessonModel addLessonModel)
        {
            var result = await LessonService.AddAsync(addLessonModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<LessonModel>> ListAsync()
        {
            return await LessonService.ListAsync();
        }

        [HttpPut("{lessonId}")]
        public async Task<IActionResult> UpdateAsync(long lessonId, UpdateLessonModel updateLessonModel)
        {
            var result = await LessonService.UpdateAsync(lessonId, updateLessonModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{lessonId}")]
        public async Task<IActionResult> DeleteAsync(long lessonId)
        {
            var result = await LessonService.DeleteAsync(lessonId);

            return new ActionIResult(result);
        }

        [HttpGet("{lessonId}")]
        public async Task<LessonModel> SelectAsync(long lessonId)
        {
            return await LessonService.SelectAsync(lessonId);
        }
    }
}