using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using DPA.Database;
using DPA.Model;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;

namespace DPA.IntegrationTest.User
{
    public class UserTest : TestBase
    {
        private long _userId;

        [Category("Integration")]
        [Order(0)]
        [Test]
        public async Task HeadOfDepartmenttShouldBeCreatedSuccessfully()
        {
            var random = new Random();
            var _mailAddress = Convert.ToChar(random.Next(97, 123)).ToString() + Convert.ToChar(random.Next(97, 123)).ToString() + Convert.ToChar(random.Next(97, 123)).ToString() + "@test.com";
            var user = new AddUserModel
            {
                Login = "test" + Convert.ToChar(random.Next(97, 123)),
                Password = "test" + Convert.ToChar(random.Next(97, 123)),
                Name = "test" + Convert.ToChar(random.Next(97, 123)),
                Surname = "test" + Convert.ToChar(random.Next(97, 123)),
                Email = _mailAddress,
                Title = Title.OgretimGorevlisi,
                Roles = Roles.Admin
            };
            await AuthenticationAsync();
            var createRequest = await Client.PostAsync("/users/headOfDepartmentt", new JsonContent(user));
            var createResult = await Check.Result<SuccessDataResult<long>>(createRequest);
            createResult.ShouldNotBeNull();
            _userId = 1;
        }

        public void Clear()
        {
            Server.Host.Services.GetRequiredService<IRepository<UserEntity>>().Delete(x => x.UserId == _userId);
        }
    }
}
