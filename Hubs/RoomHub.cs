using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Mastrowi.cz.Api.Hubs
{
    public class RoomHub : Hub
    {
        private readonly ILogger<RoomHub> logger;
        public RoomHub(ILogger<RoomHub> logger)
        {
            this.logger = logger;
        }

        public async Task Ping()
        {
            logger.LogInformation("Ping recieved");
            await Clients.All.SendAsync("Pong", DateTime.Now);
        }
    }
}
