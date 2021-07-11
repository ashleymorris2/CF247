using CF247TechTest.API.Entities;
using CF247TechTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CF247TechTest.API.Data.Contexts
{
    public sealed class CustomerContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; private set; }

        public CustomerContext(DbContextOptions options) : base(options)
        {
        }
    }
}