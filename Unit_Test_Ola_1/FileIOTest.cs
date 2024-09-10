using CPH_Pack_OLA1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Unit_Test_Ola_1
{
    public class FileIOTest
    {
        [Fact]
        public void WriteFile_ValidTask_WritesTaskToFile()
        {
            //List<int> expected = new List<int> { 1, 2, 3 };
            //List<int> actual = new List<int> { 1, 2, 3 };

            //Assert.Equal(expected, actual);
           // Arrange
           var expected = new List<TaskClass>
           {
                new TaskClass {
                    TaskName = "Test",
                    TaskValue = "Test",
                    Deadline = new DateOnly(),
                    IsCompleted = false,
                }
           };

            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(expected, options);
            
            FileIO fileIO = new FileIO();

            // Act
            fileIO.Write_File(expected);

            var actual = fileIO.Read_File();
            var jsonString2 = JsonSerializer.Serialize(actual, options);

            // Assert
            Assert.Equal(jsonString, jsonString2);
        }

        [Fact]
        public void CreatesFile_WithData_IfMissing()
        {

        }
    }
}
