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
    public class GetById : IClassFixture<ApiTestFixture>
    {
        public GetById(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnCustomerById()
        {
            var response = await Client.GetAsync("api/customer/2");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<GetByIdResponse>();

            Assert.True(model.Customer.Id == 2);
        }
    }
}
