using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF247TechTest.API.Models;

namespace CF247TechTest.API.Data
{
    public class InMemoryRepository : IRepository<CustomerDetailDto>
    {
        public Task<List<CustomerDetailDto>> GetAll()
        {
            return Task.FromResult(CustomerData.InMemoryCustomerData.Customers);
        }

        public Task<CustomerDetailDto> Get(int id)
        {
            return Task.FromResult(CustomerData.InMemoryCustomerData.Customers.FirstOrDefault(c => c.Id == id));
        }

        
        public async Task<CustomerDetailDto> Add(CustomerDetailDto entity)
        {
            var maxCustomerId = CustomerData.InMemoryCustomerData.Customers.Max(c => c.Id);

            var newCustomer = entity;
            newCustomer.Id = ++maxCustomerId;
            
            CustomerData.InMemoryCustomerData.Customers.Add(newCustomer);

            return await Task.FromResult(newCustomer);
        }

        public async Task<CustomerDetailDto> Update(CustomerDetailDto entity)
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

        public Task<CustomerDetailDto> Delete(CustomerDetailDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}