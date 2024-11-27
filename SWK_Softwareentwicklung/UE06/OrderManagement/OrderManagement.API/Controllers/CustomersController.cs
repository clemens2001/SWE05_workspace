﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.Dtos;
using OrderManagement.API.Mapperly;
using OrderManagement.Domain;
using OrderManagement.Logic;

namespace OrderManagement.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IOrderManagementLogic logic;
        public CustomersController(IOrderManagementLogic orderManagementLogic)
        {
            logic = orderManagementLogic 
                    ?? throw new ArgumentNullException(nameof(orderManagementLogic));
        }


        // GET: <base-url>/api/Customers
        // GET: <base-url>/api/Customers?rating=A
        // GET: <base-url>/api/Customers?rating=1
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomers([FromQuery] Rating? rating)
        {
            if (rating is null)
            {
                return (await logic.GetCustomersAsync()).ToDtoEnumeration();
            }
            else
            {
                return (await logic.GetCustomersByRatingAsync(rating.Value)).ToDtoEnumeration();
            }
        }

        // GET: <base-url>/api/Customers/<GUID>
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById([FromRoute] Guid customerId)     // [FromRoute] is optional
        {
            var customer = await logic.GetCustomerAsync(customerId);
            if(customer is null) {
                return NotFound();
            }
            return Ok(customer.ToDto());
        }

        // CreateCustomer
        // POST: <base-url>/api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CustomerForCreationDto customer)     // [FromBody] is optional
        {
            if(customer.Id != Guid.Empty &&
               await logic.CustomerExistsAsync(customer.Id))
            {
                return Conflict();
            }
            Customer customerDomain = customer.ToEntity();
            await logic.AddCustomerAsync(customerDomain);
            return CreatedAtAction(
                nameof(GetCustomerById),
                new { customerId = customerDomain.Id },
                customerDomain.ToDto());
        }

    }
}
