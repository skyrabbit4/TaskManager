using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repositories
{
    public class UserRepository:IUserRepository
    {

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task<List<User>>GetAsync()
        {
           return await _context.Users.Include(t=>t.Team).ToListAsync();
        }

        public async Task<User>GetAsyncId(int id)
        {
            var result =await _context.Users.Include(t=>t.Team).FirstOrDefaultAsync(t=>t.Id==id);
            return result;
        }

        
    }
}