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
    class FileIO
    {
        string docPath;

        public FileIO()
        {
            docPath = System.IO.Directory.GetCurrentDirectory() + "\\testfile.txt";
        }

        public List<TaskClass> Read_File()
        {
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new(this.docPath);

                // Read the stream as a string and deserialize content to a list
                string fileContent = reader.ReadToEnd();
                List<TaskClass> tasks = JsonSerializer.Deserialize<List<TaskClass>>(fileContent);

                // return the list to the caller.
                return tasks;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
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
