using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Mastrowi.cz.Api.Hubs
{
    public class RoomsHub : Hub
    {
        private readonly ILogger<RoomsHub> logger;
        public RoomsHub(ILogger<RoomsHub> logger)
        {
            this.logger = logger;
        }
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("Message", "Connected successfully!");
        }

        public async Task SubscribeToRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Caller.SendAsync("Message", $"Added to room `{roomId}` successfully!");
        }
        public async Task Ping()
        {
            logger.LogInformation("Ping recieved");
            await Clients.All.SendAsync("Pong", DateTime.Now);
        }
    }
}
