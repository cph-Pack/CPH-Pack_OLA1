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
        public void CreateTask_ValidTask_AddsTask()
        {
            // Arrange
            var manager = new TaskManager();

            string taskName = "Test Task";
            string taskValue = "Test Value";
            DateOnly deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            bool isCompleted = false;
            string category = "Work";

            // Act
            manager.CreateTask(taskName, taskValue, deadline, isCompleted, category);
            var task = manager.GetTask(taskName);

            // Assert
            Assert.NotNull(task);
            Assert.Equal(taskName, task.TaskName);
            Assert.Equal(taskValue, task.TaskValue);
            Assert.Equal(deadline, task.Deadline);
            Assert.Equal(isCompleted, task.IsCompleted);
            Assert.Equal(category, task.Category);
        }

        [Fact]
        public void GetTask_InvalidTask_ReturnsNull()
        {
            // Arrange 
            var manager = new TaskManager();

            // Act
            var result = manager.GetTask("NonExistentTask");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateTask_ValidTask_ReturnsModifiedTask()
        {
            // Arrange
            var manager = new TaskManager();

            string taskName = "Old Task";
            string taskValue = "Old Value";
            DateOnly deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(3));
            bool isCompleted = false;
            string newCategory = "default";

            manager.CreateTask(taskName, taskValue, deadline, isCompleted);

            string newValue = "New Value";
            DateOnly newDeadline = DateOnly.FromDateTime(DateTime.Now.AddDays(10));

            // Act
            manager.UpdateTask(taskName, newValue, newDeadline, true, newCategory);
            var updatedTask = manager.GetTask(taskName);

            // Assert
            Assert.NotNull(updatedTask);
            Assert.Equal(newValue, updatedTask.TaskValue);
            Assert.Equal(newDeadline, updatedTask.Deadline);
            Assert.True(updatedTask.IsCompleted);
        }

        // Using Test Doubles
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

        // Using Test Doubles
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
                Deadline = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
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

        [Fact]
        public void CreateTask_WithPastDeadline()
        {
            // Arrange
            var manager = new TaskManager();
            string taskName = "Test Task";
            string taskValue = "Test Value";
            DateOnly pastDeadline = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)); // Deadline in the past
            bool isCompleted = false;
            string category = "Work";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                manager.CreateTask(taskName, taskValue, pastDeadline, isCompleted, category));

            Assert.Equal("Deadline must be a future date", ex.Message);
        }
    }
}
