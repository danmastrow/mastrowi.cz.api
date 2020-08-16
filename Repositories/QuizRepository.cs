using Mastrowi.cz.Api.Exceptions;
using Mastrowi.cz.Api.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastrowi.cz.Api.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IMemoryCache cache;
        private readonly string RoomsKey = "Rooms";

        public QuizRepository(IMemoryCache cache)
        {
            this.cache = cache;

        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            var result = new List<Room>();
            if (cache.TryGetValue(RoomsKey, out List<Room> rooms))
            {
                result = rooms;
            }
            return result;
        }

        public async Task<Room> CreateRoom(string id)
        {
            Room result = new Room() { Id = id };
            if (!cache.TryGetValue(RoomsKey, out List<Room> rooms))
            {
                rooms = new List<Room>();
            } else
            {
                var roomIdAlreadyExists = rooms.FirstOrDefault(x => x.Id == id) != null;
                if (roomIdAlreadyExists)
                {
                    throw new BadRequestException($"Room with id {id} already exists");
                }
            }
            cache.Set(RoomsKey, rooms);
            rooms.Add(result);
            return result;
        }
    }
}
