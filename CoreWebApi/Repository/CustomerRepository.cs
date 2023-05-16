using CoreWebApi.DL;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public int AddCustomer(Customer Customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCustomerAsync(Customer Customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(int id, Customer Customer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(int id, Customer Customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerPatch(int id, JsonPatchDocument Customer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerPatchAsync(int id, JsonPatchDocument Customer)
        {
            throw new NotImplementedException();
        }
    }
}
