using DotNetCore.AspNetCore;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api
{
    [ApiController]
    [RouteController]
    public class ConstraintController : ControllerBase
    {
        public ConstraintController(IConstraintService constraintService)
        {
            ConstraintService = constraintService;
        }

        private IConstraintService ConstraintService { get; }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddAsync(long userId, AddConstraintModel addConstraintModel)
        {
            addConstraintModel.UserId = userId;

            var result = await ConstraintService.AddAsync(addConstraintModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<ConstraintModel>> ListAsync()
        {
            return await ConstraintService.ListAsync();
        }

        [HttpPut("{constraintId}")]
        public async Task<IActionResult> UpdateAsync(long constraintId, UpdateConstraintModel updateConstraintModel)
        {
            var result = await ConstraintService.UpdateAsync(constraintId, updateConstraintModel);

            return new ActionIResult(result);
        }

        [HttpDelete("{constraintId}")]
        public async Task<IActionResult> DeleteAsync(long constraintId)
        {
            var result = await ConstraintService.DeleteAsync(constraintId);

            return new ActionIResult(result);
        }

        [HttpGet("{constraintId}")]
        public async Task<ConstraintModel> SelectAsync(long constraintId)
        {
            return await ConstraintService.SelectAsync(constraintId);
        }
    }
}