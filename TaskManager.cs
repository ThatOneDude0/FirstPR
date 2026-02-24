using System.Net;
using static StudyTask;
using System.Linq;

namespace SmartTracker
{
    public class TaskManager
    {
        private StudyTask[] _tasks;

        int _count;
        int _nextID;

        public TaskManager()
        {
            _tasks = new StudyTask[10];
            _count = 0;
            _nextID = 1;
        }

        public void AddTask(StudyTask task)
        {
            task.Id = _nextID++;

            if(_count >= _tasks.Length)
            {   
                Array.Resize(ref _tasks, _tasks.Length * 2);
            }

            _tasksp[_count] = task;
            _count++;

            Console.WriteLine($"Task '{task.Title}' add with ID {task.Id}");
        }

        public void RemoveTask(int id)
        {
            for(int i = 0; i < _count; i++)
            {
                if(_tasks[i].Id == id)
                {
                    for(int j = i; j < _count - 1; j++)
                    {
                        _tasks[j] = _tasks[i] = null;
                    }

                    _tasks[_count -1] - null;
                    _count--;

                    Console.WriteLine($"Task with ID {id} delet");
                    return true;
                }
            }

            Console.WriteLine($"Task with ID {id} not found");
            return false;
            
        }

        public bool UpdateTask(int id, StudyTask updateTask)
        {
            for(int i = 0; i < _count; i++)
            {
                if(_tasks[i].Id == id)
                {
                    updateTask.Id = id;
                    updateTask.CreatedAt = _tasks[i].CreatedAt;

                    _tasks[i] = updateTask;
                    return true;
                }
            }
            return false;
        }

        public StudyTask GetTaskById(int id)
        {
            for(int i = 0; i<_count; i++)
            {
                if(_tasks[i].Id == id)
                {
                    return _tasks[i];
                }
            }
            return null;
        }

        public StudyTask[] GetAllTasks()
        {
            StudyTask[] result = new StudyTask[_count];

            for(int i = 0; i < _count; i++)
            {
                result[i] = _tasks[i];
            }
            return result;
        } 

        public void GetTasksByStatus(Status status){}

        public void GetTasksBySubject(string subject){}

        public void GetOverdueTasks()
        {
            for(int i = 0; i < _count; i++)
            {
                if (_tasks[i].IsOverdue())
                {
                    _tasks[i].Status = Status.Overdue;
                }
            }
        }

        public StudyTask this[int index]
        {
            get
            {
                if(index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException("The index is out of range");
                }
                return _tasks[index];
            }
            set
            {
                if(index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException("The index is out of range");
                }

                value.Id = _tasks[index].Id;
                _tasks[index]  = value;
            }
        }

        public StudyTask this [string idString]
        {
            get
            {
                if(int.TryParse(idString, out int id))
                {
                    return GetTaskById(id);
                }             
                return null;
            }
        }
    }
}