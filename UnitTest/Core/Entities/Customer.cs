using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;
using Xunit;

namespace UnitTest.Core.Entities
{
    public class CustomerPassword
    {
        private readonly string _testPassword = "testme";

        [Fact]
        public void GeneratePasswordHashAndValidate()
        {
            var builder = new CustomerBuilder();
            var testCustomer = builder.WithDefaultValues();
            testCustomer.SetPassword(_testPassword);
            Assert.NotNull(testCustomer.PasswordHash);
            Assert.True(testCustomer.ValidatePassword(_testPassword));
        }
    }
}
