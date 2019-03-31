using System;
using System.Net.Http;
using System.Threading.Tasks;
using DPA.Api;
using DPA.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace DPA.IntegrationTest
{
        public class TestServer
        {
            protected readonly Microsoft.AspNetCore.TestHost.TestServer Server;
            protected readonly HttpClient Client;

            public TestServer()
            {
                Server = new Microsoft.AspNetCore.TestHost.TestServer(WebHost.CreateDefaultBuilder()
                    .UseStartup<Startup>()
                    .UseEnvironment("Development"))
                {
                    BaseAddress = new Uri("http://dpaapi.azurewebsites.net")
                };
                Client = Server.CreateClient();
            }

            protected async Task AuthenticationAsync(string login = "admin", string password = "123456")
            {
                var response = await Client.PostAsync("/users/signin", new JsonContent(new
                {
                    login,
                    password
                }));
                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<TokenModelTest>(responseJson);
                Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {model.data.Token}");
            }

            [SetUp]
            protected virtual void Init()
            {
            }
        }

        class TokenModelTest
        {
            public TokenModel data { get; set; }
        }
}
