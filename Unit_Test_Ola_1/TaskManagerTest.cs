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
            var task = new TaskClass()
            { 
                TaskName = "Task 1",
                TaskValue = "Some Value",
                Category = "",
                Deadline = new DateOnly(2024, 9, 10),
                IsCompleted = false,
            };

            // Setup of mock behavior
            mockTaskService.Setup(service => service.GetTaskByName("Task 1"))
                .Returns(task);

            var taskManager = new TaskManagerDouble(mockTaskService.Object);

            // Act
            var result = taskManager.GetTask("Task 1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Task 1", result.TaskName);
            Assert.Equal("Some Value", result.TaskValue);
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

        // This is the specification-based task
        [Fact]
        public void CreateTask_ValidTaskWithoutCategoryWithDeadline_AddsTask()
        {
            // Arrange
            var manager = new TaskManager();

            // Act
            var expected = new TaskClass
            {
                TaskName = "A Test Task",
                TaskValue = "Test",
                Category = "Default Category", 
                Deadline = new DateOnly(),
                IsCompleted = false,
            };
            manager.CreateTask(expected.TaskName, expected.TaskValue, expected.Deadline, expected.IsCompleted);
            var actual = manager.GetTask(expected.TaskName);

            // Assert
            Assert.Equal(expected.TaskName, actual.TaskName);
            Assert.Equal(expected.TaskValue, actual.TaskValue);
            Assert.Equal(expected.Category, actual.Category);
            Assert.Equal(expected.Deadline, actual.Deadline);
            Assert.Equal(expected.IsCompleted, actual.IsCompleted);
        }
    }
}
