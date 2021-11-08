using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;
using Xunit;
using Xunit.Abstractions;

namespace IntergrationTest.Repositories.CustomerRepositoryTests
{
    public class Update
    {
        private readonly CustomersContext _customersContext;
        private readonly IRepository<Customer> _customerRepository;
        private readonly ITestOutputHelper _output;
        private Customer _testCustomer;

        public Update(ITestOutputHelper output)
        {
            var dbOptions = new DbContextOptionsBuilder<CustomersContext>()
            .UseSqlite(CreateInMemoryDatabase())
            .Options;
            _customersContext = new CustomersContext(dbOptions);
            _customersContext.Database.Migrate();
            _customerRepository = new Repository<Customer>(_customersContext);
            _output = output;

            var builder = new CustomerBuilder();
            _testCustomer = builder.WithDefaultValues();
            _testCustomer.SetPassword(CustomerBuilder.TestPassword);
            _customersContext.Add(_testCustomer);
            _customersContext.SaveChanges();
            
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        [Fact]
        public async Task UpdateWithoutConcurrencyException()
        {
            var rowversion = _testCustomer.RowVersion;
            _testCustomer.FirstName = "test";
            await _customerRepository.UpdateAsync(_testCustomer);
            Assert.NotEqual(rowversion, _testCustomer.RowVersion);
        }
    }
}
