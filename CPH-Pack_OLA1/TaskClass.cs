using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_Pack_OLA1
{
    class TaskClass
    {
        String TaskName;
        String TaskValue;
        DateOnly Deadline;
        Boolean IsCompleted;
        public TaskClass(string name, string value, DateOnly deadline, bool iscompleted) 
        {
            this.TaskName = name;
            this.TaskValue = value;
            this.Deadline = deadline;
            this.IsCompleted = iscompleted;
        }

        public string GetTaskName()
        {
            return this.TaskName;
        }

        public void SetName(string Name)
        {
            this.TaskName = Name;
        }

        public string GetTaskValue()
        {
            return this.TaskValue;
        }

        public void SetValue(string Value)
        {
            this.TaskValue = Value;
        }

        public DateOnly GetDeadline()
        {
            return this.Deadline;
        }

        public void SetDeadline(DateOnly date)
        {
            this.Deadline = date;
        }

        public Boolean GetCompleted()
        {
            return IsCompleted;
        }

        public void SetIsCompleted(bool completed)
        {
            this.IsCompleted = completed;
        }
    }
}
