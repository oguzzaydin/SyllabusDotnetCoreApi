using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using DotNetCore.Objects;
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

        [Authorize(Roles = "Administrator, Admin")]
        [HttpPost()]
        public async Task<IActionResult> AddUserAsync(AddUserModel addUserModel)
        {
            var result = await UserService.AddUserAsync(addUserModel);

            return new ActionIResult(result);
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
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

        [Authorize(Roles = "Administrator")]
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
        public async Task<ListUserModel> SelectAsync(long userId)
        {
            return await UserService.SelectAsync(userId);
        }
    }
}