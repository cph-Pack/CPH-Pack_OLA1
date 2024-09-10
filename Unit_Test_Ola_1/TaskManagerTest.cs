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
            var mockTaskService = new Mock<ITaskService>();
            var task = new TaskClass("Task 1", "Some Value", new DateOnly(2024, 9, 10), false);

            // Setup of mock behavior
            mockTaskService.Setup(service => service.GetTaskByName("Task 1"))
                .Returns(task);

            var taskManager = new TaskManagerDouble(mockTaskService.Object);

            // Act
            var result = taskManager.GetTask("Task 1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Task 1", result.GetTaskName());
            Assert.Equal("Some Value", result.GetTaskValue());
        }

        [Fact]
        public void GetTask_TaskDoesNotExist()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();

            // Setup of mock behavior to return null tasks that doesn't exist
            mockTaskService.Setup(service => service.GetTaskByName(It.IsAny<string>()))
                .Returns((TaskClass)null);

            var taskManager = new TaskManagerDouble(mockTaskService.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => taskManager.GetTask("NonExistingTask"));
        }
    }
}
