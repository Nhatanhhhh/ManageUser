using Microsoft.EntityFrameworkCore;
using ManagerUser.Context;
using ManagerUser.Models;

namespace ManagerUser.DAO
{
    public class UserDAO
    {
        private readonly AppDbContext _context;

        public UserDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow.AddHours(7);// Set the CreatedAt property to the current UTC time
            user.CreatedAt = DateTime.SpecifyKind(user.CreatedAt, DateTimeKind.Unspecified); // Đảm bảo DateTime.Kind là Unspecified hoặc Local
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
