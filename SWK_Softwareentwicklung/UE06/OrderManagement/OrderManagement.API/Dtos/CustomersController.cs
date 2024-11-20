using Microsoft.AspNetCore.Http;
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


        // GET: <base-url>/api/customers
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            return (await logic.GetCustomersAsync()).Select(c => c.ToDto());
        }
    }
}
