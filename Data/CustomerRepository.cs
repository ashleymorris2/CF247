using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF247TechTest.API.Data.Contexts;
using CF247TechTest.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CF247TechTest.API.Data
{
    public class CustomerRepository : IRepository<CustomerEntity>
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerEntity> GetAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<CustomerEntity> AddAsync(CustomerEntity entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerEntity entity)
        {
            if (!CustomerExists(entity.Id)) return null;
            
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerEntity> DeleteAsync(int id)
        {
            if (!CustomerExists(id)) return null;
            
            var customerToRemove = await  _context.Customers.FindAsync(id);
            _context.Remove(customerToRemove);
            return customerToRemove;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }
    }
}