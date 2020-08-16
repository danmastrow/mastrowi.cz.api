using System.Collections.Generic;
using System.Threading.Tasks;
using Mastrowi.cz.Api.Hubs;
using Mastrowi.cz.Api.Models;
using Mastrowi.cz.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Mastrowi.cz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IQuizRepository quizRepository;
        private readonly IHubContext<RoomsHub> roomsHub;

        public RoomsController(IQuizRepository quizRepository, IHubContext<RoomsHub> roomsHub)
        {
            this.quizRepository = quizRepository;
            this.roomsHub = roomsHub;
        }
        [HttpGet]
        public Task<IEnumerable<Room>> GetRooms()
        {
           return quizRepository.GetRooms();
        }
        [HttpPost]
        public async Task<Room> CreateRoom(CreateRoomRequest request)
        {
            var room = await quizRepository.CreateRoom(request.Id);

            return room;
        }
    }
}