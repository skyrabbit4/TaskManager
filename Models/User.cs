namespace TaskManagerAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public string Email { get; set; }

        public string? GoogleId { get; set; }

        public string  Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string?  ProfilePicture { get; set; }

        public string? Position { get; set; }

        public int TeamId {get; set;}

        public Team Team { get; set; }

    }

}