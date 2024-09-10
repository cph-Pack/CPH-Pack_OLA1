using CPH_Pack_OLA1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Ola_1
{
    public interface ITaskService
    {
        //Simpelt interface der definerer metoden GetTaskByName som returnere vores task baseret på dens navn.
        TaskClass GetTaskByName(string name);
    }

    public class TaskManagerDouble
    {
        private readonly ITaskService _taskService;

        public TaskManagerDouble(ITaskService taskService)
        {
            _taskService = taskService;
        }
        //Henter en Task
        public TaskClass GetTask(string name)
        {
            var task = _taskService.GetTaskByName(name);
            if (task == null)
            {
                throw new ArgumentException("Task not found");
            }
            return task;
        }
    }

}
