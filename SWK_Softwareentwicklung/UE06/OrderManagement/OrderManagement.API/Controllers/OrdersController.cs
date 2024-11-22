using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.API.Dtos;
using OrderManagement.API.Mapping;
using OrderManagement.Logic;

namespace OrderManagement.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderManagementLogic logic;
        public OrdersController(IOrderManagementLogic orderManagementLogic)
        {
            logic = orderManagementLogic
                    ?? throw new ArgumentNullException(nameof(orderManagementLogic));
        }

        //GetOrdersOfCustomer
        // GET: <base-url>/api/Customers/<customerId>/Orders
        [HttpGet("/customers/{customerId}/orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersOfCustomer([FromRoute] Guid customerId)
        {
            if(!await logic.CustomerExistsAsync(customerId)) {
                return NotFound();
            }

            var ordersOfCustomers = await logic.GetOrdersOfCustomerAsync(customerId);
            return Ok(ordersOfCustomers.Select(o => o.ToDto()));
        }
    }
}
