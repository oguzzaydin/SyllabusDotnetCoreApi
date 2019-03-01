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

        public SyllabusController(ISyllabusService syllabusService)
        {
            SyllabusService = syllabusService;
        }

        private ISyllabusService SyllabusService { get; }

        [HttpGet("{departmanId}")]
        public async Task<SyllabusEntity> SingleOrDefaultUserAsync(long departmanId)
        {
            return await SyllabusService.SelectAsync(departmanId);
        }
    }
}