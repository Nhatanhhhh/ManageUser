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

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userDAO.GetUserByIdAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email cannot be empty.");

            return await _userDAO.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userDAO.DeleteUserAsync(id);
        }

        public async Task<List<User>> SearchUsersAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return await _userDAO.GetAllUsersAsync();

            return await _userDAO.SearchUsersAsync(searchTerm);
        }
    }
}
