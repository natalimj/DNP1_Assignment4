using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyApp.Models;

namespace FamilyApp.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task AddUserAsync(User user);
        Task<IList<User>> GetUsersAsync();
        Task<IList<User>> GetBasicUsersAsync();
        Task RemoveUserAsync(User user);
    }
}