using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.CustomerEndpoints;
using Xunit;

namespace FunctionalTests.CustomersEndpoints
{
    [Collection("Sequential")]
    public class List : IClassFixture<ApiTestFixture>
    {
        public List(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsAllCustomers()
        {
            var response = await Client.GetAsync("/api/customer");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<CustomerListResponse>();

            Assert.True(model.Customers.Count() > 0);
        }
    }
}
