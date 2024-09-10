using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CPH_Pack_OLA1
{
     class Program
    {
        public static Boolean running = true;
        public static List<TaskClass> TaskList = new List<TaskClass>();
        public static Dictionary<String ,List<TaskClass>> TaskGroups = new Dictionary<string, List<TaskClass>>();
        
        static void Main(string[] args)
        {

            FileIO fileIO = new FileIO();

            //TaskGroups.Add("Default Group", new List<TaskClass>());
            //int State = 0;
            //while (running)
            //{
            //    if (State == 0)
            //    {
            //        Console.WriteLine("Welcome to task manager uwu\r");
            //        Console.WriteLine("What would you like to do?");

            //        Console.WriteLine("\t1 - Add a task");
            //        Console.WriteLine("\t2 - Update a task");
            //        Console.WriteLine("\t3 - Delete task");
            //        Console.WriteLine("\t4 - Mark task as completed");
            //        Console.WriteLine("\t5 - Show All Tasks");
            //        Console.WriteLine("\t6 - Add Task Group");
            //        Console.WriteLine("\t7 - Show all Groups");
            //        Console.WriteLine("\t8 - Move Task to other Group");

            //        Console.WriteLine("\t99 - Exit");

            //        switch (Console.ReadLine())
            //        {
            //            case "0":
            //                State = 0;
            //                break;
            //            case "1":
            //                State = 1;
            //                break;
            //            case "2":
            //                State = 2;
            //                break;
            //            case "3":
            //                State = 3;
            //                break;
            //            case "4":
            //                State = 4;
            //                break;
            //            case "5":
            //                State = 5;
            //                break;
            //            case "6":
            //                State = 6;
            //                break;
            //            case "7":
            //                State = 7;
            //                break;

            //            case "99":
            //                State = 99;
            //                break;
            //        }
            //    }

            //    if (State == 1)
            //    {
            //        String TName = "";
            //        String TValue = "";
            //        String GroupName = "";
            //        Console.WriteLine("Enter Task Name:");
            //        TName = Console.ReadLine();
            //        Console.WriteLine("Enter Task Value");
            //        TValue = Console.ReadLine();
            //        Console.WriteLine("Enter group (default if empty)");
            //        GroupName = Console.ReadLine();
            //        if (GroupName.Equals(""))
            //        {
            //            GroupName = "Default Group";
            //        }
            //        try
            //        {
            //            TaskGroups[GroupName].Add(new TaskClass(TName, TValue, new DateOnly(2024, 9, 9), false));
            //        }
            //        catch
            //        {
            //            Console.WriteLine("there aren't any groups with that name");
            //        }
            //        State = 0;
            //    }

            //    if (State == 3)
            //    {
            //        Console.WriteLine("Which Task Group?");
            //        foreach (String s in TaskGroups.Keys.ToList())
            //        {
            //            Console.WriteLine(s);
            //        }
            //        Console.WriteLine("Enter group name (leave blank to cancel");
            //        List<TaskClass> tmpList = new List<TaskClass>();
            //        String tmpName = Console.ReadLine();
            //        try
            //        {
            //            tmpList = TaskGroups[tmpName];
            //        }
            //        catch
            //        {
            //            Console.WriteLine("There's no group with that name");
            //            State = 0;
            //        }
            //        if(tmpList.Count == 0)
            //        {
            //            Console.WriteLine("it's empty ._.");
            //            State = 0;
            //        }
            //        else
            //        {
            //            for(int i = 0; i < tmpList.Count; i++)
            //            {
            //                Console.WriteLine("\t" + i + ": " + tmpList[i].GetTaskName() + " - " + tmpList[i].GetTaskValue());
            //            }
            //            Console.WriteLine("Remove which task? (leave blank to cancel) >:3");
            //            String tmp = Console.ReadLine();
            //            int tmpID = -1;
            //            if(tmp == "")
            //            {
            //                State = 0;
            //            }
            //            try
            //            {
            //                tmpID = Int32.Parse(tmp);
            //            }
            //            catch
            //            {
            //                Console.WriteLine("Give number not name >:(");
            //                State = 0;
            //            }
            //            Console.WriteLine("Removing " + TaskGroups[tmpName][tmpID].GetTaskName());
            //        }
            //        State = 0;
            //    }

            //    if (State == 4)
            //    {

            //    }

            //    if (State == 5)
            //    {
            //        List<String> keys = TaskGroups.Keys.ToList();
            //        for(int i = 0; i < keys.Count; i++)
            //        {
            //            Console.WriteLine(keys[i].ToString());
            //            for(int k = 0; k < TaskGroups[keys[i]].Count; k++)
            //            {
            //                Console.WriteLine("\t" + k + ": " + TaskGroups[keys[i]][k].GetTaskName() + " - " + TaskGroups[keys[i]][k].GetTaskValue());
            //            }
            //        }
            //        State = 0;
            //    }

            //    if(State == 6)
            //    {
            //        Console.WriteLine("Enter new Group name:");
            //        TaskGroups.Add(Console.ReadLine(), new List<TaskClass>());
            //        State = 0;
            //    }

            //    if (State == 7)
            //    {
            //        Console.WriteLine("List of groups:");
            //        List<String> tmpList = TaskGroups.Keys.ToList();
            //        for(int i = 0; i < tmpList.Count; i++)
            //        {
            //            Console.WriteLine(tmpList[i]);
            //        }
            //        State = 0;
            //    }


            //    if(State == 99)
            //    {
            //        running = false;
            //    }
            //}
        }
    }
}
