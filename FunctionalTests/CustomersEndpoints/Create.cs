using Core.Extensions;
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
    public class Create : IClassFixture<ApiTestFixture>
    {
        public Create(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsSuccessGivenValidNewItem()
        {
            var jsonContent = GetValidNewItem();
            var response = await Client.PostAsync("api/customer/create", jsonContent);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<CreateCustomerResponse>();
            Assert.True(model.Customer.Id > 0);
        }

        private StringContent GetValidNewItem()
        {
            var request = new CreateCustomerRequest()
            {
                Firstname = "testing",
                Lastname = "testing",
                Email = "some.email@testing.com",
                Password = "password"
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            return jsonContent;
        }
    }
}
