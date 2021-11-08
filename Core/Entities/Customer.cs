using Core.Helper;
using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Customer : ConcurrentEntity, IAggregateRoot
    {
        private string _password;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }


        public void SetPassword(string password)
        {
            PasswordHash = SecurePasswordHasher.Hash(password, 1);
        }

        public bool ValidatePassword(string password)
        {
            return SecurePasswordHasher.Verify(password, PasswordHash);
        }

        public static Customer Create(string firstname, string lastname, string email, string password)
        {
            Customer customer = new Customer();
            customer.FirstName = firstname;
            customer.LastName = lastname;
            customer.Email = email;
            customer.SetPassword(password);
            return customer;
        }
    }
}
