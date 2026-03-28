
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Controllers;
using TaskManagerAPI.Data;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repositories
{
    public class TeamRepository:ITeamRepository
    {
        private readonly  AppDbContext _context;
        public TeamRepository(AppDbContext context )
        {
          _context=context;
        }


        public async Task<List<Team>> GetTeamAsync()
        {
            var result= await _context.Teams.Include(t=>t.Organization).ToListAsync();
            return  result;
        }

        public async Task<Team?>GetTeamByIdAsync(int id)
        {
            var result = await _context.Teams.Include(t=>t.Organization).FirstOrDefaultAsync(t=>t.Id==id);
            return result;
        }

        public async Task<Team>CreateTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateTeamAsync(int id,Team team)
        {
            var result= await _context.Teams.FindAsync(id);
            if(result==null)
            {
                return null;
            }

            result.Name=team.Name;
            result.Description=team.Description;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool>DeleteTeamAsync(int id)
        {
           var result= await _context.Teams.FindAsync(id);
           if(result==null)
            {
                return false;
            }

            var hasProjects = await _context.Projects.AnyAsync(p => p.TeamId == id);
    if (hasProjects)
    {
        throw new InvalidOperationException("Cannot delete team with existing projects");
    }

    _context.Teams.Remove(result);
    await _context.SaveChangesAsync();
    return true;

        }



    }
}