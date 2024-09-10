using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CPH_Pack_OLA1
{
    public class FileIO
    {
        string docPath;

        public FileIO()
        {
            this.docPath = System.IO.Directory.GetCurrentDirectory() + "\\testfile.txt";
        }

        private void Create_File_With_Data()
        {
            var testTask = new TaskClass()
            {
                TaskName = "Writing unit tests",
                TaskValue = "100",
                Deadline = new DateOnly(),
                IsCompleted = false,
            };
            var testTask2 = new TaskClass()
            {
                TaskName = "Compiling code",
                TaskValue = "100",
                Deadline = new DateOnly(),
                IsCompleted = false,
            };
            List<TaskClass> tasks = new List<TaskClass>();
            tasks.Add(testTask);
            tasks.Add(testTask2);
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(this.docPath, jsonString);
        }

        private bool File_exists()
        {
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new(this.docPath);
                string fileContent = reader.ReadToEnd();
                if (fileContent == "")
                {
                    reader.Close();
                    Create_File_With_Data();
                    
                }
                return true;
            }
            catch (IOException e)
            {
                Create_File_With_Data();
            }
            return true;
        }


        public List<TaskClass> Read_File()
        {
            try
            {
                
                if (File_exists() == true)
                {
                    // Open the text file using a stream reader.
                    using StreamReader reader = new(this.docPath);

                    // Read the stream as a string and deserialize content to a list
                    string fileContent = reader.ReadToEnd();
                    List<TaskClass> tasks = JsonSerializer.Deserialize<List<TaskClass>>(fileContent);
                
                    // return the list to the caller.
                    return tasks;
                }
            }
            catch (IOException e)
            {
                throw new FileNotFoundException("Incorrect file path");
            }
            return null;
        }

        public void Write_File(List<TaskClass> tasks)
        {

            // prepare options, convert array to json string and write to file
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(this.docPath, jsonString);

        }

        // will be deleted but this was the old method
        public void Write_File_Old(TaskClass task)
        {
            // read content
            List<TaskClass> tasks = Read_File();

            // add new task
            tasks.Add(task);

            // prepare options, convert array to json string and write to file
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(this.docPath, jsonString);

        }


    }
}
