using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api
{
    [Authorize(Roles = "Admin, User")]
    [ApiController]
    [RouteController]
    public class ConstraintController : ControllerBase
    {
        public ConstraintController(IConstraintService constraintService)
        {
            ConstraintService = constraintService;
        }

        private IConstraintService ConstraintService { get; }

        /// <summary>
        /// Kısıt Ekleme hangi kullanıcı ROL Admin ve User için
        /// </summary>
        [HttpPost("{userId}")]
        public async Task<IActionResult> AddAsync(long userId, AddConstraintModel addConstraintModel)
        {
            addConstraintModel.UserId = userId;

            var result = await ConstraintService.AddAsync(addConstraintModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Tüm Kısıtları listeler
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<ListConstraintModel>> ListAsync()
        {
            return await ConstraintService.ListAsync();
        }

        /// <summary>
        /// Update
        /// </summary>
        [HttpPut("{constraintId}")]
        public async Task<IActionResult> UpdateAsync(long constraintId, UpdateConstraintModel updateConstraintModel)
        {
            var result = await ConstraintService.UpdateAsync(constraintId, updateConstraintModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Delete
        /// </summary>
        [HttpDelete("{constraintId}")]
        public async Task<IActionResult> DeleteAsync(long constraintId)
        {
            var result = await ConstraintService.DeleteAsync(constraintId);

            return new ActionIResult(result);
        }

        /// <summary>
        /// GetById
        /// </summary>
        [HttpGet("{constraintId}")]
        public async Task<ListConstraintModel> SelectAsync(long constraintId)
        {
            return await ConstraintService.SelectAsync(constraintId);
        }
    }
}