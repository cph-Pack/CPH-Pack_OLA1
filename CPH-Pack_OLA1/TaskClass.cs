using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_Pack_OLA1
{
    public class TaskClass
    {
        public required String TaskName { get; set; }
        public required String TaskValue { get; set; }
        public required string Category { get; set; }
        public DateOnly Deadline { get; set; } = new DateOnly();
        public Boolean IsCompleted { get; set; } = false;
        //public String TaskName;
        //public String TaskValue;
        //public DateOnly Deadline;
        //public Boolean IsCompleted;
        ////public TaskClass(string name, string value, DateOnly deadline, bool iscompleted) 
        ////{
        ////    this.TaskName = name;
        ////    this.TaskValue = value;
        ////    this.Deadline = deadline;
        ////    this.IsCompleted = iscompleted;
        ////}

        //public string GetTaskName()
        //{
        //    return this.TaskName;
        //}

        //public void SetName(string Name)
        //{
        //    this.TaskName = Name;
        //}

        //public string GetTaskValue()
        //{
        //    return this.TaskValue;
        //}

        //public void SetValue(string Value)
        //{
        //    this.TaskValue = Value;
        //}

        //public DateOnly GetDeadline()
        //{
        //    return this.Deadline;
        //}

        //public void SetDeadline(DateOnly date)
        //{
        //    this.Deadline = date;
        //}

        //public Boolean GetCompleted()
        //{
        //    return IsCompleted;
        //}

        //public void SetIsCompleted(bool completed)
        //{
        //    this.IsCompleted = completed;
        //}
    }
}
