using LibraryManager.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManager.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}

