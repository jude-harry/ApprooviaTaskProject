
namespace Application.DTOS
{
    public class TaskDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public int AllottedTime { get; set; }
        public int ElapsedTime { get; set; }
        public bool TaskStatus { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public int DaysOverdue { get; set; }
        public int DaysLate { get; set; }    
     
    }
    public class TaskBaseDto : TaskDto
    {
        public int TaskID { get; set; }
    }
}
