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
    public class DepartmentController : ControllerBase
    {
        public DepartmentController(IDepartmentService departmentService)
        {
            DepartmentService = departmentService;
        }

        private IDepartmentService DepartmentService { get; }



        /// <summary>
        /// Bölüm ekleme CRUD işlemleri Role = Administrator, Admin
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddDepartmentModel addDepartmentModel)
        {
            var result = await DepartmentService.AddAsync(addDepartmentModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Bölüm Başkanını getirir
        /// </summary>
        [HttpGet("{DepartmentId}/user")]
        public async Task<UserModel> SingleOrDefaultUserAsync(long DepartmentId)
        {
            return await DepartmentService.SingleOrDefaultUserAsync(DepartmentId);
        }
        /// <summary>
        /// Bölüme ait ders programlarını getirir
        /// </summary>
        [HttpGet("{DepartmentId}/syllabus")]
        public async Task<SyllabusModel> SingleOrDefaultSyllabusAsync(long DepartmentId)
        {
            return await DepartmentService.SingleOrDefaultSyllabusAsync(DepartmentId);
        }

        /// <summary>
        /// Bölüm Başkanı için Bölüm bilgilerini getirir
        /// </summary>
        [HttpGet("getDepartmentForHeadOfDepartment/{userId}")]
        public async Task<ListDepartmentModel> GetDepartmentForHeadOfDepartmentAsync(long userId)
        {
            return await DepartmentService.GetDepartmentForHeadOfDepartmentAsync(userId);
        }

        [HttpGet]
        public async Task<IEnumerable<ListDepartmentModel>> ListAsync()
        {
            return await DepartmentService.ListAsync();
        }

        [HttpPut("{DepartmentId}")]
        public async Task<IActionResult> UpdateAsync(long DepartmentId, UpdateDepartmentModel updateDepartmentModel)
        {
            var result = await DepartmentService.UpdateAsync(DepartmentId, updateDepartmentModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Bölüm Başkanını Günceller
        /// </summary>
        [HttpPut("{DepartmentId}/user/{userId}")]
        public async Task<IActionResult> UpdateUserAsync(long DepartmentId, long userId)
        {
            var result = await DepartmentService.UpdateUserAsync(DepartmentId, userId);

            return new ActionIResult(result);
        }

        [HttpDelete("{DepartmentId}")]
        public async Task<IActionResult> DeleteAsync(long DepartmentId)
        {
            var result = await DepartmentService.DeleteAsync(DepartmentId);

            return new ActionIResult(result);
        }

        [HttpGet("{DepartmentId}")]
        public async Task<DepartmentModel> SelectAsync(long DepartmentId)
        {
            return await DepartmentService.SelectAsync(DepartmentId);
        }
    }
}