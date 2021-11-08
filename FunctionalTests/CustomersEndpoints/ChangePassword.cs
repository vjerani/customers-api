using Core.Extensions;
using Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.CustomerEndpoints;
using Xunit;

namespace FunctionalTests.CustomersEndpoints
{
    [Collection("Sequential")]
    public class ChangePassword : IClassFixture<ApiTestFixture>
    {
        public ChangePassword(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsSuccessGivenChangePasswordItem()
        {
            var jsonContent = ChangePasswordItem();
            var updateResponse = await Client.PutAsync("api/customer/password", jsonContent);
            updateResponse.EnsureSuccessStatusCode();
            var stringResponse = await updateResponse.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<ChangePasswordResponse>();
            Assert.NotNull(model);
        }

        private StringContent ChangePasswordItem()
        {
            var request = new ChangePasswordRequest()
            {
                Id = 3,
                NewPassword = "newpassword"
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            return jsonContent;
        }
    }
}
