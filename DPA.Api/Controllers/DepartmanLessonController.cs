using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api.Controllers
{
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
    }
}