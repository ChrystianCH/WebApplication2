using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskController : ControllerBase
	{
		private readonly TaskManager _tasks;
		public TaskController(TaskManager tasks) {
			_tasks = tasks;
		}

		// GET: api/<TaskController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Task>>> GetAllTasks()
		{
			return _tasks.GetTasks();
		}

		// GET api/<TaskController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Task>> GetTask(int id)
		{
			return _tasks.GetTaskById(id);
		}

		// POST: api/<TaskController>
		[HttpPost]
		public void CreateTask(Task value)
		{
			_tasks.AddTask(value);
		}

		// PUT: api/<TaskController>/5
		[HttpPut("{id}")]
		public void UpdateTask(int id, Task value)
		{
			_tasks.UpdateTask(id, value);
		}

		// DELETE: api/<TaskController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			 _tasks.DeleteTask(id);
		}
	}
}
