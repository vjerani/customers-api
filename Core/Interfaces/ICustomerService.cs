using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(string firstname, string lastname, string email, string password);
        Task ChangePasswordAsync(int Id, string newPassword);
        Task DeleteCustomerAsync(int id);
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> UpdateCustomerAsync(int id, string firstname, string lastname, string email, long version);
        Task<bool> ValidatePasswordAsync(int id, string password);
    }
}