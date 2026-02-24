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
        Cоmpleted,
        Overdue
    }

    public class StudyTask
    {
        internal Status Status;

        public int Id {get; set;}

        public string Title {get; set;}

        public string Subject {get; set;}

        public string Description {get; set;}

        public DateTime Deadline {get; set;}

        public Priority Priority {get; set;}

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
            Status = Status.Cоmpleted;
            ActualHours = hoursSpent;
            CompletedAt = DateTime.Now;
        }

        public bool IsOverdue()
        {
            return Status != Status.Cоmpleted && DateTime.Now > Deadline;
        }
    }
}