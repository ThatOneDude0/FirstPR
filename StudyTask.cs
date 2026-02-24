using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using SmartTracker;

namespace SmartTracker
{
     public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        NotStarted,
        InProgress,
        COmpleted,
        Overdue
    }

    public class StudyTask
    {
        public int Id {get; set;}

        public string Title {get; set;}

        public string Subject {get; set;}

        public string Deadline {get; set;}

        public int EstimatedHours {get; set;}

        public int ActualHours {get; set;}

        public DateTime CreatedAt {get; set;}

        public DateTime? CompletedAt {get; set;}

        public StudyTask()
        {
            CreatedAt = DateTime.Now;
            Status = Status.NotStarted;
            ActualHours = 0;
            CompletedAt = null;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} ({Subject}) - {Status} to {Deadline:dd.MM.yyyy}";
        }

        public void MarkAsCompleted(int hoursSpent)
        {
            Status = Status.COmpleted;
            ActualHours = hoursSpent;
            CompletedAt = DateTime.Now;
        }

        public bool IsOverdue()
        {
            return Status != Status.COmpleted && DateTime.Now > Deadline;
        }
    }
}