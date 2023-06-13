using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BLL.Models;
using TodoList.DAL.Entities;

namespace TodoList.BLL.Interfaces
{
    public interface IUserService
    {
        Task<(bool successful, string msg)> Create(UserVM model);
        Task<(bool successful, string msg)> Update(UserVM model);

        Task<(bool successful, string msg)> DeleteAsync(int userId);
        Task<IEnumerable<UserVM>> GetUsers();
        Task<UserVM> GetUser(int userId);
        Task<IEnumerable<UserWithTaskVM>> GetUsersWithTasksAsync();
        Task<(bool successful, string msg)> AddOrUpdateAsync(UserVM model);
    }
}