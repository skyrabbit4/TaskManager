using Microsoft.AspNetCore.Authorization.Infrastructure;
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

        public async Task<User?>GetByIdAsync(int id)
        {
            var result =await _context.Users.Include(t=>t.Team).FirstOrDefaultAsync(t=>t.Id==id);
            return result;
        }

        public async Task<User>CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User>UpdateAsync(int id, User user)
        {
            var result = await _context.Users.FindAsync(id);
            if(result==null)
            {
                return null;
            }
            result.Name=user.Name;
            result.Role=user.Role;
            result.ProfilePicture=user.ProfilePicture;
            result.Position=user.Position;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result=await _context.Users.FindAsync(id);
              if(result==null)
            {
                return false;
            }

            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }


        
    }
}