using TaskManagerAPI.Models;

namespace TaskManagerAPI.DTOs
{
    public class CreateTeamDto
    {    
        public string Name{ get; set; }

        public string Description { get; set; }

        public int OrganizationId { get; set; }

    }

}