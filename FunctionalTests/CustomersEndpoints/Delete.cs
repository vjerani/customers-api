using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.CustomerEndpoints;
using Xunit;

namespace FunctionalTests.CustomersEndpoints
{
    [Collection("Sequential")]
    public class Delete : IClassFixture<ApiTestFixture>
    {
        public Delete(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsSuccessGivenValidId()
        {
            var updateResponse = await Client.DeleteAsync("api/customer/delete/1");
            updateResponse.EnsureSuccessStatusCode();
            var stringResponse = await updateResponse.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<DeleteCustomerResponse>();
            Assert.NotNull(model);
        }

        [Fact]
        public async Task ReturnsNotFoundGivenInvalidId()
        {
            var response = await Client.DeleteAsync("api/catalog-items/0");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
