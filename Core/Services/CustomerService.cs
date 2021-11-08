using Ardalis.GuardClauses;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<Customer> AddCustomerAsync(string firstname, string lastname, string email, string password)
        {
            Guard.Against.NullOrWhiteSpace(firstname, nameof(firstname));
            Guard.Against.NullOrWhiteSpace(lastname, nameof(lastname));
            Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Guard.Against.NullOrWhiteSpace(password, nameof(password));

            var customer = Customer.Create(firstname, lastname, email, password);
            await _customerRepository.InsertAndGetIdAsync(customer);
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, string firstname, string lastname, string email, long version)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer.RowVersion != version)
            {
                throw new ConcurrencyException();
            }

            customer.FirstName = firstname;
            customer.LastName = lastname;
            customer.Email = email;
            await _customerRepository.UpdateAsync(customer);
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            Guard.Against.Zero(id, nameof(id));
            await _customerRepository.DeleteAsync(id);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task ChangePasswordAsync(int id, string newPassword)
        {
            Guard.Against.Zero(id, nameof(id));
            Guard.Against.NullOrWhiteSpace(newPassword, nameof(newPassword));
            var customer = await _customerRepository.GetByIdAsync(id);
            customer.SetPassword(newPassword);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task<bool> ValidatePasswordAsync(int id, string password)
        {
            Guard.Against.Zero(id, nameof(id));
            Guard.Against.NullOrWhiteSpace(password, nameof(password));
            var customer = await _customerRepository.GetByIdAsync(id);
            return customer.ValidatePassword(password);
        }
    }
}
