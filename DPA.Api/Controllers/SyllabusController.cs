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
        public async Task<SyylabusForDepartmentDTo> CreateSyllabus([FromBody] CreateSyllabusRequest request)
            => await _syllabusService.CreateSyllabus(request);

        [AllowAnonymous]
        [HttpGet("{departmentId}")]
        public async Task<IEnumerable<SyylabusForDepartmentDTo>> GetSyllabusForDepartment(long departmentId)
             => await _syllabusService.GetSyllabusForDepartment(departmentId);

        [AllowAnonymous]
        [HttpGet("{departmentId}/firstActiveSyllabus")]
        public SyylabusForDepartmentDTo GetFirstSyllabusForDepartment(long departmentId)
             =>  _syllabusService.GetFirstSyllabusForDepartment(departmentId);


        [AllowAnonymous]
        [HttpGet("{departmentId}/secondActiveSyllabus")]
        public  SyylabusForDepartmentDTo GetSecondSyllabusForDepartment(long departmentId)
             =>  _syllabusService.GetSecondSyllabusForDepartment(departmentId);
    }
}