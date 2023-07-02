using WebApplication2;
using Task = WebApplication2.Task;

namespace TestProject1
{
	public class Tests
	{
		private TaskManager _taskManager;
		[SetUp]
		public void Setup()
		{
			_taskManager = new TaskManager();
		}
		[Test]
		public void AddTask_ShouldIncreaseTaskCount()
		{
			// Arrange
			var task = new Task("Test task");
			// Act
			_taskManager.AddTask(task);
			// Assert
			Assert.AreEqual(3, _taskManager.GetTasks().Count);
		}
		[Test]
		public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
		{
			//Arrange
			var task = new Task("Test task");
			_taskManager.AddTask(task);
			// Act
			_taskManager.RemoveTask(task.Id);
			//Assert
			Assert.AreEqual(2, _taskManager.GetTasks().Count);
		}
		[Test]
		public void RemoveTask_NonExistingTask_ShouldNotChangeTaskCount()
		{
			//Arrange
			var task = new Task("Test task");
			_taskManager.AddTask(task);
			// Act
			_taskManager.RemoveTask(task.Id + 10);
			//Assert
			Assert.AreEqual(3, _taskManager.GetTasks().Count);
		}
		[Test]
		public void MarkTaskAsCompleted_ExistingTask_ShouldMarkTaskAsCompleted()
		{
			//Arrange
			var task = new Task("Test task");
			_taskManager.AddTask(task);
			// Act
			_taskManager.MarkTaskAsCompleted(task.Id);
			//Assert
			Assert.AreEqual(true, task.IsCompleted);
		}
		[Test]
		public void MarkTaskAsCompleted_NonExistingTask_ShouldNotMarkTaskAsCompleted()
		{
			//Arrange
			var task = new Task("Test task");
			_taskManager.AddTask(task);
			// Act
			_taskManager.MarkTaskAsCompleted(task.Id + 20);
			//Assert
			Assert.AreEqual(false, task.IsCompleted);
		}
		[Test]
		public void GetTasks_ShouldReturnAllTasks()
		{
			//Arrange
			var task = new List<Task>();
			// Act
			task = _taskManager.GetTasks();
			//Assert
			Assert.IsNotNull(task);
		}
	}
}