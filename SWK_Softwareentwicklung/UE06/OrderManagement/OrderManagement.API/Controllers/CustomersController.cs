using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Api.BackgroundServices;
using OrderManagement.Api.Controllers;
using OrderManagement.API.Dtos;
using OrderManagement.API.Mapperly;
using OrderManagement.Domain;
using OrderManagement.Logic;

namespace OrderManagement.API.Controllers
{

    [ApiConventionType(typeof(WebApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IOrderManagementLogic logic;
        private readonly UpdateChannel updateChannel;

        public CustomersController(
            IOrderManagementLogic orderManagementLogic,
            UpdateChannel updateChannel)
        {
            logic = orderManagementLogic 
                    ?? throw new ArgumentNullException(nameof(orderManagementLogic));
            this.updateChannel = updateChannel
                    ?? throw new ArgumentNullException(nameof(updateChannel));
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
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
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
                return Conflict(StatusInfo.CustomerAlreadyExists(customer.Id));
            }
            Customer customerDomain = customer.ToEntity();
            await logic.AddCustomerAsync(customerDomain);
            return CreatedAtAction(
                nameof(GetCustomerById),
                new { customerId = customerDomain.Id },
                customerDomain.ToDto());
        }


        // UpdateCustomer
        // PUT: <base-url>/api/Customers/<GUID>
        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(
            [FromRoute] Guid customerId, 
            [FromBody] CustomerForUpdateDto customerDto)
        {
            Customer? customer = await logic.GetCustomerAsync(customerId);

            if (customer is null)
            {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            customerDto.UpdateCustomer(customer);
            await logic.UpdateCustomerAsync(customer);
            return NoContent();
        }

        // DeleteCustomer
        // DELETE: <base-url>/api/Customers/<GUID>

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] Guid customerId)
        {
            if(await logic.DeleteCustomerAsync(customerId)) {
                return NoContent();
            } else {
                return NotFound();
            }
        }

        // Update customer totals
        // POST: <base-url>/api/Customers/<GUID>/totals
        [HttpPost("{customerId}/totals")]
        public async Task<ActionResult> UpdateCustomerTotals(
            Guid customerId, 
            CancellationToken cancellationToken)
        {
            if(!await logic.CustomerExistsAsync(customerId)) {
                return NotFound(StatusInfo.InvalidCustomerId(customerId));
            }

            if(await updateChannel.AddUpdateTaskAsync(customerId, cancellationToken)) {
                return Accepted();
            }

            return BadRequest(new ProblemDetails()
            {
                Title ="Operation cancelled",
                Detail = "Update customer totals cancelled"
            });
        }

    }
}
