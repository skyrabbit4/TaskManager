using TaskManagerAPI.Models;

namespace TaskManagerAPI.Interfaces
{
    public interface IUserRepository
    {

       Task<List<User>>GetAsync();
       Task<User?>GetByIdAsync(int id);
       Task<User>CreateAsync(User user);
       Task<User?>UpdateAsync(int id, User user);
       Task<bool>DeleteAsync(int id);
    }
}