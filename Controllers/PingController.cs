using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mastrowi.cz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Ok";
        }
    }
}
