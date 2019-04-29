using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application.UnitLesson;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api.Controllers
{
    // [Authorize(Roles = "Admin")]
    [ApiController]
    [RouteController]
    public class UnitLessonController : ControllerBase
    {
        public readonly IUnitLessonService _unitLessonService;

        public UnitLessonController(IUnitLessonService unitLessonService)
        {
            _unitLessonService = unitLessonService;
        }

        [HttpPut()]
        [Authorize(Roles = "Administrator")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(UpdateUnitLessonModel request)
        {
            var result = await _unitLessonService.UpdateAsync(request);

            return new ActionIResult(result);
        }

    }
}