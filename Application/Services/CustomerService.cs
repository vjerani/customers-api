using Application.Dtos;
using Application.Interfaces;
using Ardalis.GuardClauses;
using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService: IApplicationService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Add(CustomerDto model, string password)
        {
            Guard.Against.NullOrWhiteSpace(model.FirstName, nameof(model.FirstName));
            Guard.Against.NullOrWhiteSpace(model.LastName, nameof(model.LastName));
            Guard.Against.NullOrWhiteSpace(model.Email, nameof(model.Email));
            Guard.Against.NullOrWhiteSpace(password, nameof(password));

            var customer = Customer.Create(model.FirstName, model.LastName, model.Email, password);
            await _customerRepository.InsertAndGetIdAsync(customer);
            return customer;

        }

        public async Task Update(Customer customer)
        {
            Guard.Against.NullOrWhiteSpace(password, nameof(password));

        }

        public async Task ChangePassword(int Id, string newPassword)
        {
            Guard.Against.Zero(Id, nameof(Id));
            Guard.Against.NullOrWhiteSpace(newPassword, nameof(newPassword));
            var customer = await _customerRepository.GetByIdAsync(Id);
            customer.SetPassword(newPassword);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
