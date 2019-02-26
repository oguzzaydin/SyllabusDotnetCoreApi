using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using DPA.Application;
using DPA.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DPA.Api
{
    [ApiController]
    [RouteController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        private IUserService UserService { get; }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromQuery, BindRequired]AddUserModel addUserModel)
        {
            var result = await UserService.AddAsync(addUserModel);

            return new ActionIResult(result);
        }
        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [AllowAnonymous]
        [HttpPost("SignIn")]
        [ProducesResponseType(typeof(SignInModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SignInAsync(SignInModel signInModel)
        {
            var result = await UserService.SignInJwtAsync(signInModel);

            return new ActionIResult(result);
        }

        [HttpPost("SignOut")]
        public Task SignOutAsync()
        {
            var signOutModel = new SignOutModel(User.Id());

            return UserService.SignOutAsync(signOutModel);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(long userId)
        {
            var result = await UserService.DeleteAsync(userId);

            return new ActionIResult(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(long userId, UpdateUserModel updateUserModel)
        {
            var result = await UserService.UpdateAsync(userId, updateUserModel);

            return new ActionIResult(result);
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await UserService.ListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<UserModel> SelectAsync(long userId)
        {
            return await UserService.SelectAsync(userId);
        }
    }
}