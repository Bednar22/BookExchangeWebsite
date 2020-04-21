using System.Threading.Tasks;
using BookExchange.API.Models;

namespace BookExchange.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExist(string username);
    }
}