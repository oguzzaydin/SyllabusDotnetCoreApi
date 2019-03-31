using System;
using System.Threading.Tasks;
using DotNetCore.Objects;
using DPA.Model;
using NUnit.Framework;
using Shouldly;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DPA.Test.User
{
    public class UserTest : TestBase
    {
        [Category("Integration")]
        [Order(0)]
        [Test]
        public async Task UserShouldBeCreatedSuccessfully()
        {
            var random = new Random();
            var _mailAddress = Convert.ToChar(random.Next(97, 123)).ToString() + Convert.ToChar(random.Next(97, 123)).ToString() + Convert.ToChar(random.Next(97, 123)).ToString() + "@test.com";
            var user = new AddUserModel
            {
                Name = "Oguzhan",
                Surname = "Aydin",
                Email = _mailAddress,
                Login = "oguz",
                Password = "123456",
                Title = Title.AraştırmaGörevlisi,
                Roles = Roles.Admin,
            };
            var createRequest = await Client.PostAsync("/users/headOfDepartmant", new JsonContent(user));
            var creatResult = await Check.Result<IDataResult<long>>(createRequest);
            creatResult.ShouldNotBeNull();
        }
    }
}
