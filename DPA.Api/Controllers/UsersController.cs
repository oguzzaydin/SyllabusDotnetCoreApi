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

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromQuery, BindRequired]AddUserModel addUserModel)
        {
            var result = await UserService.AddAsync(addUserModel);

            return new ActionIResult(result);
        }
        /// <summary>
        /// Kullanıcı girişi yapılan methodu
        /// </summary>
        /// <remarks>SignIn Methodu Açıklaması!</remarks>
        /// <response code="200">Başarılı giriş yapıldığında aşağadıki model dönmektedir.</response>
        /// <response code="400">SignInModel yok veya valid değil ise  (Aşağıdaki model örnek amaçlı hatalı olarak verilmiştir.)
        /// Kullanıcı adı veya şifresi hatalı mesajı dönecektir.</response>
        /// <response code="500">Oops! Kullanıcı girişi şu anda yapılamadı</response>
        [AllowAnonymous]
        [HttpPost("SignIn")]
        [ProducesResponseType(typeof(IDataResult<TokenModel>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SignInAsync(SignInModel signInModel)
        {
            var result = await UserService.SignInJwtAsync(signInModel);

            return new ActionIResult(result);
        }

        /// <summary>
        /// Kullanıcı çıkış yaparken log tutulması içindir.
        /// </summary>
        /// <remarks>SignOut Methodu Açıklaması!</remarks>
        [HttpPost("SignOut")]
        public Task SignOutAsync()
        {
            var signOutModel = new SignOutModel(User.Id());

            return UserService.SignOutAsync(signOutModel);
        }

        /// <summary>
        /// Kullanıcı silme işlemi şuan için sadece sistem yetkili tarafından yapılacaktır.
        /// </summary>
        /// <remarks>User Delete Methodu Açıklaması!</remarks>
        /// <response code="200">Başarılı giriş yapıldığında aşağadıki model dönmektedir.</response>
        /// <response code="400">Gönderilen Id ye ait kullanıcı mevcut değil veya id gönderilmediyse</response>
        /// <response code="500">Oops! Kullanıcı şu anda silinemedi</response>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{userId}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
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