using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace Hotelll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromForm] CreateRoomDto createRoomDto)
        {
            await roomRepository.CreateRoomAsync(createRoomDto);

            return Ok("Created");
        }
        [HttpGet("clientId")]
        public async Task<IActionResult> GetRoomById(Guid roomId)
        {
            var room = await roomRepository.GetRoomByIdAsync(roomId);

            return Ok(room);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await roomRepository.GetAllAsync();

            return Ok(rooms);
        }
        [HttpDelete("roomId")]
        public async Task<IActionResult> DeleteRoomById(Guid roomId)
        {
            var room = await roomRepository.DeleteRoomByIdAsync(roomId);
            if (room is true)
            {
                return Ok("Deleted");
            }
            else return BadRequest("NotFound");
        }
        [HttpPut("{roomId}")]
        public async Task<IActionResult> UpdateRoomName(Guid roomId, CreateRoomDto roomDto)
        {
            var rooms = await roomRepository.UpdateRoomAsync(roomId, roomDto);

            return Ok(rooms);
        }
    }
}
