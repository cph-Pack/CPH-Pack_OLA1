using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPH_Pack_OLA1
{
    internal class TaskClass
    {
        UniqueId TaskID;
        String TaskName = "";
        String TaskValue = "";
        Boolean Completed = false;
        public TaskClass(string name, string value)
        {
            this.TaskID = new UniqueId();
            this.TaskName = name;
            this.TaskValue = value;
        }

        public UniqueId GetID()
        {
            return this.TaskID;
        }

        public String GetTaskName()
        {
            return this.TaskName;
        }

        public void SetTaskName(String taskName)
        {
            this.TaskName = taskName;
        }

        public String GetTaskValue()
        {
            return this.TaskValue;
        }

        public void SetTaskValue(String taskValue)
        {
            this.TaskValue = taskValue;
        }

        public Boolean IsCompleted()
        {
            return this.Completed;
        }

        public void SetCompeted(Boolean isCompleted)
        {
            this.Completed = isCompleted;
        }
    }
}
