namespace TaskManagerAPI.Models
{
    
    public class SubTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }
        

        public string? Status {get; set;}

        public int? OrderIndex {get; set;}

        public int TaskId {get; set;}
        public TaskItem TaskItem {get; set;}


    }
}