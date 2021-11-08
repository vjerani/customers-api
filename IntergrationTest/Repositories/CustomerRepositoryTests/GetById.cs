using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;
using Xunit;
using Xunit.Abstractions;

namespace IntergrationTest.Repositories.CustomerRepositoryTests
{
    public class GetById
    {
        private readonly CustomersContext _customersContext;
        private readonly IRepository<Customer> _customerRepository;
        private readonly ITestOutputHelper _output;

        public GetById(ITestOutputHelper output)
        {
            var dbOptions = new DbContextOptionsBuilder<CustomersContext>()
                .UseInMemoryDatabase(databaseName: "TestCustomers")
                .Options;
            _customersContext = new CustomersContext(dbOptions);
            _customerRepository = new Repository<Customer>(_customersContext);
            _output = output;
        }

        [Fact]
        public async Task GetsExistingCustomer()
        {
            var builder = new CustomerBuilder();
            var testCustomer = builder.WithDefaultValues();
            testCustomer.SetPassword(CustomerBuilder.TestPassword);
            _customersContext.Add(testCustomer);
            _customersContext.SaveChanges();

            _output.WriteLine($"Id: {testCustomer.Id}");
            var existingCustomer = await _customerRepository.GetByIdAsync(testCustomer.Id);
            Assert.Equal(existingCustomer.Id, testCustomer.Id);
        }

        [Fact]
        public async Task ThrowsErrorOnNotFoundCustomer()
        {
            await Assert.ThrowsAsync<EntityNotFoundException>(() => _customerRepository.GetByIdAsync(2));
        }
    }
}
