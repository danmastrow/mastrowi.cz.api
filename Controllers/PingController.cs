using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mastrowi.cz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Ok";
        }
    }
}
