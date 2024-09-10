using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPH_Pack_OLA1
{

    public class TaskManager
    {
        private List<TaskClass> tasks;
        private int nextId = 1;
        private FileIO fileIO;

        public TaskManager()
        {
            fileIO = new FileIO();
            tasks = fileIO.Read_File() ?? new List<TaskClass>();
            //tasks = new List<TaskClass>();
        }

        // Create a new task
        public void CreateTask(string name, string value, DateOnly deadline, bool isCompleted)
        {
            var task = new TaskClass(name, value, deadline, isCompleted);
            tasks.Add(task);
            SaveTasks();
            Console.WriteLine($"Task '{name}' created.");
        }

        // Read a specific task by name
        public TaskClass GetTask(string name)
        {
            var task = tasks.FirstOrDefault(t => t.GetTaskName() == name);
            if (task != null)
            {
                Console.WriteLine($"Task found: {task.GetTaskName()} - {task.GetTaskValue()} - Deadline: {task.GetDeadline()} - Completed: {task.GetCompleted()}");
            }
            else
            {
                Console.WriteLine($"Task with name '{name}' not found.");
            }
            return task;
        }

        // Read all tasks
        public List<TaskClass> GetAllTasks()
        {
            return tasks;
        }

        // Update an existing task by name
        public List<TaskClass> UpdateTask(string name, string newValue, DateOnly newDeadline, bool isCompleted)
        {
            var task = tasks.FirstOrDefault(t => t.GetTaskName() == name);
            if (task != null)
            {
                task.SetValue(newValue);
                task.SetDeadline(newDeadline);
                task.SetIsCompleted(isCompleted);
                SaveTasks();
                Console.WriteLine($"Task '{name}' updated.");
            }
            else
            {
                Console.WriteLine($"Task with name '{name}' not found.");
            }
            return tasks;
        }

        // Delete a task by name
        public void DeleteTask(string name)
        {
            var task = tasks.FirstOrDefault(t => t.GetTaskName() == name);
            if (task != null)
            {
                tasks.Remove(task);
                SaveTasks();
                Console.WriteLine($"Task '{name}' deleted.");
            }
            else
            {
                Console.WriteLine($"Task with name '{name}' not found.");
            }

            void SaveTasks()
            {
                fileIO.Write_File(tasks);
            }

        }
    }
}
