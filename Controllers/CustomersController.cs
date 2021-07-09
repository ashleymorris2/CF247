using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CF247TechTest.API.Data;
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
        private readonly IRepository<CustomerDetailDto> _repository;
        private readonly IMapper _mapper ;
        
        public CustomersController(ILogger<CustomersController> logger, IRepository<CustomerDetailDto> repository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            _logger.LogInformation("A request was made to retrieve all customers");
            
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}", Name = GetCustomerRouteName)]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var customer = await  _repository.Get(id);

            if (customer == null)
            {
                return NotFound();
            }
            
            _logger.LogInformation($"A request was made to retrieve customer with id {id}, found customer: {customer.FirstName} {customer.Surname}");
            
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerDto customer)
        {
            var newCustomer = await _repository.Add(_mapper.Map<CustomerDetailDto>(customer));
            
            _logger.LogInformation($"A new customer was created with the {newCustomer.Id}");
            
            return CreatedAtRoute(GetCustomerRouteName, new {id = newCustomer.Id}, newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customer)
        {
            var newCustomer = _mapper.Map<CustomerDetailDto>(customer);
            newCustomer.Id = id;
            
            var updatedCustomer = await _repository.Update(newCustomer);
            
            if (updatedCustomer == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Customer was cid {id} has been updated");
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerToDelete = CustomerData.InMemoryCustomerData.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToDelete == null)
            {
                return NotFound();
            }

            CustomerData.InMemoryCustomerData.Customers.Remove(customerToDelete);

            _logger.LogInformation($"Customer was cid {id} has been deleted");
            
            return NoContent();
        }
    }
}