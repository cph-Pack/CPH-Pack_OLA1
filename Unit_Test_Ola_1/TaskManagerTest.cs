using CPH_Pack_OLA1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Ola_1
{
    public class TaskManagerTests
    {
        [Fact]
        public void GetTask_TaskExists_ReturnsTask()
        {
            // Arrange
            // We create a mock of our interface
            var mockTaskService = new Mock<ITaskService>();
            // We create an instance of TaskClass, in this case we use the name "Task 1".
            var task = new TaskClass("Task 1", "Some Value", new DateOnly(2024, 9, 10), false);

            // Setup of mock behavior
            //With help from our Mock setup, we define that GetTaskByName gets called with the value "task 1".
            mockTaskService.Setup(service => service.GetTaskByName("Task 1"))
                .Returns(task);

            var taskManager = new TaskManagerDouble(mockTaskService.Object);

            // Act
            // We create a TaskManagerDouble and call the method GetTask("Task 1").
            var result = taskManager.GetTask("Task 1");

            // Assert
            // We make sure that our result isn't "null".
            Assert.NotNull(result);
            // We write down what results we expect and compare to the actual results.
            Assert.Equal("Task 1", result.GetTaskName());
            Assert.Equal("Some Value", result.GetTaskValue());
        }

        [Fact]
        public void GetTask_TaskDoesNotExist()
        {
            // Arrange
            // We create another mock of our interface.
            var mockTaskService = new Mock<ITaskService>();

            // Setup of mock behavior to return null tasks that doesn't exist
            mockTaskService.Setup(service => service.GetTaskByName(It.IsAny<string>()))
                .Returns((TaskClass)null);

            
            var taskManager = new TaskManagerDouble(mockTaskService.Object);

            // Act & Assert
            // We call upon the GetTask for a task that deosn't exist.
            Assert.Throws<ArgumentException>(() => taskManager.GetTask("NonExistingTask"));
        }
    }
}
