using TaskManagerAPI.Models;

namespace TaskManagerAPI.DTOs
{
   public class UpdateProjectDto
    {
        public string? Name { get; set; }
        

        public DateTime EndDate {get; set;}

        public string? Description { get; set; }

        public string? Status {get; set;}

       public int TeamId {get; set;}

       public Team? Team {get; set;}


    }



}