using Domain.Entyties;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateRoomAsync(CreateRoomDto room)
        {
            var roomCreate = new Room()
            {
                Name = room.Name,
                Id = Guid.NewGuid()
            };

            await dbContext.rooms.AddAsync(roomCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoomByIdAsync(Guid roomId)
        {
            var room = dbContext.rooms.FirstOrDefault(ex => ex.Id == roomId);
            if (room is not null)
            {
                dbContext.rooms.Remove(room);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await dbContext.rooms.ToListAsync();
        }

        public Task<Room> GetRoomByIdAsync(Guid roomId)
        {
            var room = dbContext.rooms.FirstOrDefaultAsync(ex => ex.Id == roomId);

            return room;
        }

        public async Task<Room> UpdateRoomAsync(Guid roomId, CreateRoomDto roomDto)
        {
            var room = await dbContext.rooms.FirstOrDefaultAsync(e => e.Id == roomId);

            room.Name = roomDto.Name;
            await dbContext.SaveChangesAsync();
            return room;
        }
    }
}
