namespace TaskManagerAPI.DTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string  Role { get; set; }
        public string?  ProfilePicture { get; set; }

        public string? Position { get; set; }
        public int TeamId {get; set;}
    }
}