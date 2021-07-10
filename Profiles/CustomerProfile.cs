using AutoMapper;
using CF247TechTest.API.Entities;
using CF247TechTest.API.Models;

namespace CF247TechTest.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerDetailDto>();
        }
    }
}