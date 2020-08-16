using System.ComponentModel.DataAnnotations;

namespace Mastrowi.cz.Api.Models
{
    public class CreateRoomRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
