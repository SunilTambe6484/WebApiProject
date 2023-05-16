using CoreWebApi.DL;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Task<List<Customer>> GetAllCustomersAsync();

        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);

        int AddCustomer(Customer Customer);
        Task<int> AddCustomerAsync(Customer Customer);

        void UpdateCustomer(int id, Customer Customer);
        Task UpdateCustomerAsync(int id, Customer Customer);

        void UpdateCustomerPatch(int id, JsonPatchDocument Customer);
        Task UpdateCustomerPatchAsync(int id, JsonPatchDocument Customer);

        void DeleteCustomer(int id);
        Task DeleteCustomerAsync(int id);
    }
}
