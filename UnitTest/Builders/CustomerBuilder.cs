using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Builders
{
    public class CustomerBuilder
    {
        public const string TestFirstName = "Firstname";
        public const string TestLastName = "Surname";
        public const string TestEmail = "mail@domain.com";
        public const string TestPassword = "testme";
        public long RowVersion = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        public CustomerBuilder()
        {
        }

        public Customer WithDefaultValues()
        {
            return new Customer
            {
                FirstName = TestFirstName,
                LastName = TestLastName,
                Email = TestEmail
            };
        }
    }
}
