using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF247TechTest.API.Data.Contexts;
using CF247TechTest.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CF247TechTest.API.Data
{
    public class EfCustomerRepository : IRepository<CustomerEntity>
    {
        private readonly CustomerContext _context;

        public EfCustomerRepository(CustomerContext context)
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

        public Task<CustomerEntity> UpdateAsync(CustomerEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerEntity> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}