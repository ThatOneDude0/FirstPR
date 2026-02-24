using System;
using System.Linq;

namespace SmartTracker
{
    class Program
    {
        static TaskManager manager = new TaskManager();
        
        static void Main()
        {
            Console.WriteLine("SMART TRACKER\n");
            
            while (true)
            {
                Console.WriteLine("\n1. Add a task");
                Console.WriteLine("2. All tasks");
                Console.WriteLine("3. Find by ID");
                Console.WriteLine("4. Complete a task");
                Console.WriteLine("5. Delete task");
                Console.WriteLine("6. Statistics");
                Console.WriteLine("7. Search by text");
                Console.WriteLine("8. Check for expired");
                Console.WriteLine("0. Exit");
                Console.Write("> ");
                
                string cmd = Console.ReadLine();
                if (cmd == "0") break;
                
                switch (cmd)
                {
                    case "1": AddTask(); break;
                    case "2": ShowAll(); break;
                    case "3": FindById(); break;
                    case "4": CompleteTask(); break;
                    case "5": DeleteTask(); break;
                    case "6": ShowStats(); break;
                    case "7": SearchTasks(); break;
                    case "8": CheckOverdue(); break;
                    default: Console.WriteLine("Unknown"); break;
                }
            }
        }
        
        static void AddTask()
        {
            StudyTask task = new StudyTask();
    
            Console.Write("Name: "); 
            task.Title = Console.ReadLine();
    
            Console.Write("Item: "); 
            task.Subject = Console.ReadLine();
    
            Console.Write("Description: "); 
            task.Description = Console.ReadLine();
    
            Console.Write("Term (YYYY-MM-DD): ");
            task.Deadline = DateTime.TryParse(Console.ReadLine(), out DateTime date) 
                ? date 
                : DateTime.Now.AddDays(7);
    
            Console.Write("Priority (1-Low, 2-Medium, 3-High): ");
            string p = Console.ReadLine();
            task.Priority = p == "1" ? Priority.Low : p == "3" ? Priority.High : Priority.Medium;
    
            Console.Write("Planned time (hours): ");
            // ИСПРАВЛЕНО: используем тернарный оператор с временной переменной
            task.EstimatedHours = int.TryParse(Console.ReadLine(), out int hours) ? hours : 0;
    
            manager.AddTask(task);
            Console.WriteLine("Task added");
}
        
        static void ShowAll()
        {
            var tasks = manager.GetAllTasks();
            if (tasks.Length == 0) Console.WriteLine("No tasks");
            else foreach (var t in tasks) Console.WriteLine(t);
        }
        
        static void FindById()
        {
            Console.Write("ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = manager.GetTaskById(id);
                if (task != null) Console.WriteLine(task);
                else Console.WriteLine("Not found");
            }
        }
        
        static void CompleteTask()
        {
            Console.Write("Task ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = manager.GetTaskById(id);
                if (task != null && task.Status != Status.Cоmpleted)
                {
                    Console.Write("How many hours did you spend: ");
                    int.TryParse(Console.ReadLine(), out int hours);
                    task.MarkAsCompleted(hours);
                    Console.WriteLine("Done!");
                }
                else Console.WriteLine("Not found or already completed");
            }
        }
        
        static void DeleteTask()
        {
            Console.Write("Task ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                manager.RemoveTask(id);
        }
        
        static void ShowStats()
        {
            var stats = new Statistics(manager.GetAllTasks());
            Console.WriteLine(stats.GetReport());
        }
        
        static void SearchTasks()
        {
            Console.Write("What are we looking for:");
            string search = Console.ReadLine();
            var found = manager.SearchTasks(search);
            if (found.Length == 0) Console.WriteLine("There is nothing");
            else foreach (var t in found) Console.WriteLine(t);
        }
        
        static void CheckOverdue()
        {
            manager.GetOverdueTasks();
            Console.WriteLine("Verified");
        }
    }
}