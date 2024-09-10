using CPH_Pack_OLA1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Ola_1
{
    public class FileIOTest
    {
        [Fact]
        public void WriteFile_ValidTask_WritesTaskToFile()
        {
            // Arrange
            var expected = new List<TestTask>
        {
            new TestTask {
                TaskName = "Test",
                TaskValue = "Test",
                Deadline = new DateOnly(),
                IsCompleted = false,
            }
        };

            FileIO fileIO = new FileIO();

            // Act
            fileIO.Write_File(expected);

            var actual = fileIO.Read_File();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
