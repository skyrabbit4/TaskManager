namespace TaskManagerAPI.Models
{
    
    public class Team
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public string? Description{ get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrganizationId {get; set;}
        public Organization Organization { get; set; }

    }
}