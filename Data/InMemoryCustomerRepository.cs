using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF247TechTest.API.Models;

namespace CF247TechTest.API.Data
{
    public class InMemoryRepository : IRepository<CustomerDetailDto>
    {
        public async Task<IEnumerable<CustomerDetailDto>> GetAllAsync()
        {
            return await Task.FromResult(CustomerData.InMemoryCustomerData.Customers);
        }

        public Task<CustomerDetailDto> GetAsync(int id)
        {
            return Task.FromResult(CustomerData.InMemoryCustomerData.Customers.FirstOrDefault(c => c.Id == id));
        }
        
        public Task<CustomerDetailDto> AddAsync(CustomerDetailDto entity)
        {
            var maxCustomerId = CustomerData.InMemoryCustomerData.Customers.Max(c => c.Id);

            var newCustomer = entity;
            newCustomer.Id = ++maxCustomerId;
            
            CustomerData.InMemoryCustomerData.Customers.Add(newCustomer);

            return Task.FromResult(newCustomer);
        }

        public async Task<CustomerDetailDto> UpdateAsync(CustomerDetailDto entity)
        {
            var customerToUpdate = CustomerData.InMemoryCustomerData.Customers.FirstOrDefault(c => c.Id == entity.Id);

            if (customerToUpdate != null)
            {
                customerToUpdate.FirstName = entity.FirstName;
                customerToUpdate.Surname = entity.Surname;
                customerToUpdate.Email = entity.Email;
                customerToUpdate.Password = entity.Password;
            }
   
            return await Task.FromResult(customerToUpdate);
        }

        public async Task<CustomerDetailDto> DeleteAsync(int id)
        {
            var customerToDelete = CustomerData.InMemoryCustomerData.Customers.FirstOrDefault(c => c.Id == id);
            
            if (customerToDelete != null)
            {
                CustomerData.InMemoryCustomerData.Customers.Remove(customerToDelete);
            }
            
            return await Task.FromResult(customerToDelete);
        }
    }
}