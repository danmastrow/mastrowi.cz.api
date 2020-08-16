using Mastrowi.cz.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastrowi.cz.Api.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> CreateRoom(string id); 
    }
}
