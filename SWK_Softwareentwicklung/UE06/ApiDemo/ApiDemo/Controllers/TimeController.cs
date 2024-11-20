using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("/time2")]
    [ApiController]
    public class TimeController : ControllerBase
    {

        [HttpGet]
        public object Get()
        {
            return new { Time = DateTime.UtcNow.ToString("o") };
        }
    }
}
