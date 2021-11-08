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
    public class Update : IClassFixture<ApiTestFixture>
    {
        public Update(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsSuccessGivenValidUpdateItem()
        {
            var jsonContent = GetValidUpdateItem();
            var updateResponse = await Client.PutAsync("api/customer/update", jsonContent);
            updateResponse.EnsureSuccessStatusCode();
            var stringResponse = await updateResponse.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<UpdateCustomerResponse>();
            Assert.True(model.Customer.Id == 2 && model.Customer.Firstname == "update");
        }

        private StringContent GetValidUpdateItem()
        {
            var request = new UpdateCustomerRequest()
            {
                Id = 2,
                Firstname = "update",
                Lastname = "test",
                Email = "test",
                Version = 0
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            return jsonContent;
        }
    }
}
