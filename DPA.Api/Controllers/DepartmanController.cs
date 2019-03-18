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
    public class DepartmanController : ControllerBase
    {
        public DepartmanController(IDepartmanService departmanService)
        {
            DepartmanService = departmanService;
        }

        private IDepartmanService DepartmanService { get; }



        /// <summary>
        /// Bölüm ekleme CRUD işlemleri Role = Administrator, Admin
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmanModel addDepartmanModel)
        {
            var result = await DepartmanService.AddAsync(addDepartmanModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Bölümün öğretim üyelerini getirir
        /// </summary>
        [HttpGet("{departmanId}/user")]
        public async Task<UserModel> SingleOrDefaultUserAsync(long departmanId)
        {
            return await DepartmanService.SingleOrDefaultUserAsync(departmanId);
        }
        /// <summary>
        /// Bölüme ait ders programlarını getirir
        /// </summary>
        [HttpGet("{departmanId}/syllabus")]
        public async Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long departmanId)
        {
            return await DepartmanService.SingleOrDefaultSyllabusAsync(departmanId);
        }

        [HttpGet]
        public async Task<IEnumerable<ListDepartmanModel>> ListAsync()
        {
            return await DepartmanService.ListAsync();
        }

        [HttpPut("{departmanId}")]
        public async Task<IActionResult> UpdateAsync(long departmanId, UpdateDepartmanModel updateDepartmanModel)
        {
            var result = await DepartmanService.UpdateAsync(departmanId, updateDepartmanModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Bölümün öğretim üyelerini günceller
        /// </summary>
        [HttpPut("{departmanId}/user/{userId}")]
        public async Task<IActionResult> UpdateUserAsync(long departmanId, long userId)
        {
            var result = await DepartmanService.UpdateUserAsync(departmanId, userId);

            return new ActionIResult(result);
        }

        [HttpDelete("{departmanId}")]
        public async Task<IActionResult> DeleteAsync(long departmanId)
        {
            var result = await DepartmanService.DeleteAsync(departmanId);

            return new ActionIResult(result);
        }

        [HttpGet("{departmanId}")]
        public async Task<DepartmanModel> SelectAsync(long departmanId)
        {
            return await DepartmanService.SelectAsync(departmanId);
        }
    }
}