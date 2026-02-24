using System;
using System.Linq;

namespace SmartTracker
{
    public class Statistics
    {
        private StudyTask[] tasks;
        
        public Statistics(StudyTask[] taskArray)
        {
            tasks = taskArray;
        }
        
        public string GetReport()
        {
            int total = tasks.Length;
            int completed = tasks.Count(t => t.Status == Status.Cоmpleted);
            int overdue = tasks.Count(t => t.Status == Status.Overdue);
            
            return $"Total: {total}\nDone: {completed}\nOverdue: {overdue}";
        }
    }
}