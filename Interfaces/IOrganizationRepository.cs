using TaskManagerAPI.Models;

namespace TaskManagerAPI.Interfaces
{
    
    public interface IOrganizationRepository
    {
        Task<List<Organization>>GetAllAsync();

        Task<Organization?>GetByIdAsync(int id);

        Task<Organization>CreateAsync(Organization organization);

        Task<Organization?>UpdateAsync(int id, Organization organization);
        
        Task<bool>DeleteAsync(int id);

    }
}