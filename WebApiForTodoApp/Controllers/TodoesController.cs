using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiForTodoApp.Models;
using WebApiForTodoApp.Repository;
using WebApiForTodoApp.Service;

namespace WebApiForTodoApp.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class TodoesController : ApiController
	{
		private readonly ITodoRepository _repository;
		private readonly ITodoService _service;

		public TodoesController(ITodoRepository repository, ITodoService service)
		{
			_repository = repository;
			_service = service;
		}
		
		public IQueryable<Todo> GetTodos()
		{
			return _service.GetAllTodos();
		}

		public IHttpActionResult PostTodo(Todo todo)
		{
			if (!_service.CreateTodo(todo))
				return NotFound();

			return Ok(todo);
		}

		public IHttpActionResult PutTodo(int id, Todo todo)
		{
			if (!_service.EditTodo(todo) && (todo != null || id != todo.Id))
				return NotFound();

			_service.EditTodo(todo);

			return Ok();
		}

		// DELETE: api/Todoes/5
		public IHttpActionResult DeleteTodo(int id)
		{
			var existingTodo = _repository.GetById(id);
			if (existingTodo == null && _service.RemoveTodo(existingTodo))
				return NotFound();

			_service.RemoveTodo(existingTodo);

			return Ok(existingTodo);
		}
	}
}