using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Api
{
    [Authorize(Roles = "Admin")]
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
        public async Task<SyllabusEntity> CreateSyllabus([FromBody] CreateSyllabusRequest request)
            => await _syllabusService.CreateSyllabus(request);

        [AllowAnonymous]
        [HttpGet("{DepartmentId}")]
        public async Task<IEnumerable<SyylabusForDepartmentDTo>> GetSyllabusForDepartment(long DepartmentId)
             => await _syllabusService.GetSyllabusForDepartment(DepartmentId);
    }
}