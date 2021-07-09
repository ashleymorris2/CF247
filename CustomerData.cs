using System.Collections.Generic;
using CF247TechTest.API.Models;

namespace CF247TechTest.API
{
    public class CustomerData
    {
        public static CustomerData InMemoryCustomerData { get; } = new CustomerData();
        
        public List<CustomerDetailDto> Customers { get; }

        private CustomerData()
        {
            Customers = new List<CustomerDetailDto>()
            {
                new CustomerDetailDto()
                {
                    Id = 1, FirstName = "Gary", Surname = "Oaks", Email = "gary@gmail.com", Password = "hello-there"
                },
                new CustomerDetailDto()
                {
                    Id = 2, FirstName = "Crispin", Surname = "Crisp", Email = "glover@gmail.com", Password = "password"
                },
                new CustomerDetailDto()
                {
                    Id = 3, FirstName = "Helen", Surname = "Helenson", Email = "helen@gmail.com",
                    Password = "lemonandlime"
                },
                new CustomerDetailDto()
                {
                Id = 4, FirstName = "Barry", Surname = "Hill", Email = "helen@gmail.com",
                Password = "lemonandlime"
            }
            };
        }
    }
}