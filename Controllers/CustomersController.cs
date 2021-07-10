using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CF247TechTest.API.Data;
using CF247TechTest.API.Entities;
using CF247TechTest.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CF247TechTest.API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private const string GetCustomerRouteName = "GetCustomer";

        private readonly ILogger<CustomersController> _logger;
        private readonly IRepository<CustomerEntity> _repository;
        private readonly IMapper _mapper;

        public CustomersController(ILogger<CustomersController> logger, IRepository<CustomerEntity> repository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _repository.GetAllAsync();

            _logger.LogInformation("A request was made to retrieve all customers");

            return Ok(_mapper.Map<IEnumerable<CustomerDetailDto>>(customers));
        }

        [HttpGet("{id}", Name = GetCustomerRouteName)]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _repository.GetAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"A request was made to retrieve customer with id {id}");

            return Ok(_mapper.Map<CustomerDetailDto>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer)
        {
            var newCustomer = await _repository.AddAsync(_mapper.Map<CustomerEntity>(customer));

            _logger.LogInformation($"A new customer was created with the ID {newCustomer.Id}");

            return CreatedAtRoute(GetCustomerRouteName, new {id = newCustomer.Id},
                _mapper.Map<CustomerDetailDto>(newCustomer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            var customerToUpdate = _mapper.Map<CustomerEntity>(customer);
            customerToUpdate.Id = id;

            if (await _repository.UpdateAsync(customerToUpdate) == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Customer with ID {id} has been updated");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _repository.DeleteAsync(id) == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Customer with ID {id} has been deleted");

            return NoContent();
        }
    }
}