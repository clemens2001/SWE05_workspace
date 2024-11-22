using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.Dtos;
using OrderManagement.API.Mapping;
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
                return (await logic.GetCustomersAsync()).Select(c => c.ToDto());
            }
            else
            {
                return (await logic.GetCustomersByRatingAsync(rating.Value)).Select(c => c.ToDto());
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

    }
}
