namespace TaskManagerAPI.Models

{
    public class TaskItem
    {
      public int Id { get; set; }

      public DateTime? EndDate {get; set;}

      public DateTime? StartDate {get; set;}

      public string Title { get; set; }

      public string Status {get; set;}

      public string Priority {get; set;}

      public DateTime CreatedAt { get; set; }

      public DateTime UpdatedAt { get; set; }

      public string? Description {get; set;}

      public int? EffortHours { get; set; }

      public int ProjectId {get; set;}
      public Project Project {get;set;}

      public int CreatedBy {get; set;}

      public User CreatedByUser {get; set;}

      public int AssignedTo {get ; set;}

      public User AssignedToUser {get ; set;}


    }

}