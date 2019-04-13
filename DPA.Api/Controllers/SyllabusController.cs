using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api
{
    [Authorize(Roles = "Admin, User")]
    [ApiController]
    [RouteController]
    public class SyllabusController : ControllerBase
    {
        private readonly ISyllabusService _syllabusService;

        public SyllabusController(ISyllabusService syllabusService)
        {
            _syllabusService = syllabusService;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateSyllabus([FromBody] CreateSyllabusRequest request)
        {
            _syllabusService.CreateSyllabus(request);
            return Ok();
        }

        [HttpGet("{DepartmentId}")]
        public async Task<SyllabusEntity> SingleOrDefaultUserAsync(long DepartmentId)
        {
            return await _syllabusService.SelectAsync(DepartmentId);
        }
    }
}