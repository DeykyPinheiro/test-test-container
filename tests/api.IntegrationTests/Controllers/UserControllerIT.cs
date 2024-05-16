using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace api.IntegrationTests.Controllers
{
    public class UserControllerIT : IClassFixture<apiWebApplicationFactory>
    {
        private readonly apiWebApplicationFactory _apiWebApplicationFactory;

        public UserControllerIT(apiWebApplicationFactory apiWebApplicationFactory)
        {
            _apiWebApplicationFactory = apiWebApplicationFactory;
        }

        [Fact]
        public async Task GetAll_Returns_Ok()
        {
            var client = _apiWebApplicationFactory.CreateClient();

            var response = await client.GetAsync("api/Users");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var users = await response.Content.ReadFromJsonAsync<User[]>();
            Assert.NotNull(users);
        }
    }
}
