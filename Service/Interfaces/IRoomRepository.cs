using Domain.Entyties;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface IRoomRepository
    {
        public Task CreateRoomAsync(CreateRoomDto room);
        public Task<Room> GetRoomByIdAsync(Guid roomId);
        public Task<List<Room>> GetAllAsync();
        public Task<bool> DeleteRoomByIdAsync(Guid roomId);
        public Task<Room> UpdateRoomAsync(Guid roomId, CreateRoomDto roomDto);
    }
}
