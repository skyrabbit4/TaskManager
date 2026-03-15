namespace TaskManagerAPI.Models
{
   public class Project
    {
        public int Id {get; set;}

        public string Name { get; set; }

        public DateTime StartDate {get; set;}

        public DateTime EndDate {get; set;}

        public string? Description { get; set; }

        public string? Status {get; set;}

       public DateTime CreatedAt { get; set; }

       public DateTime UpdatedAt { get; set; }

       public int TeamId {get; set;}

       public Team Team {get; set;}

       public int CreatedBy { get; set;}

       public User CreatedByUser {get; set;}

    }



}