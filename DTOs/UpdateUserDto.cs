namespace TaskManagerAPI.DTOs
{
    public class UpdateUserDto
    {
        public string Name { get; set; }

        public string  Role { get; set; }
        public string?  ProfilePicture { get; set; }

        public string? Position { get; set; }
    }
}