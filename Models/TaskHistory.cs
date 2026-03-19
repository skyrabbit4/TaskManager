

namespace TaskManagerAPI.Models
{
    
    public class  TaskHistory
    {
        
        public int Id {get; set;}

        public string FieldChanged {get; set;}

        public DateTime ChangedAt {get; set;}


        public string? NewValue {get; set;}

        public string?  OldValue {get; set;}

        public int ChangedBy {get; set;}

        public User? ChangedByUser {get; set;}
         
         public int TaskId {get; set;}

         public TaskItem? TaskItem {get; set;}
}

        

}