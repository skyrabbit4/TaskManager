using TaskManagerAPI.Models;

namespace TaskManagerAPI.Interfaces
{
    
    public interface ITeamRepository
    {
        Task<List<Team>>GetTeamAsync();
        Task<Team?>GetTeamByIdAsync(int id);

        Task<Team>CreateTeamAsync(Team team);

        Task<Team?>UpdateTeamAsync(int id, Team team);

        Task<bool>DeleteTeamAsync(int id);
        

    }
}
