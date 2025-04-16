using ManagerUser.DAO;
using ManagerUser.Models;

namespace ManagerUser.Repository
{
    public class UserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userDAO.GetAllUsersAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            // Logic nghiệp vụ: Kiểm tra email hợp lệ
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email cannot be empty.");

            return await _userDAO.CreateUserAsync(user);
        }
    }
}
