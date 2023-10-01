
namespace Domain.Entities;

public  class TaskProject
{
    public int Id { get; set; }
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

