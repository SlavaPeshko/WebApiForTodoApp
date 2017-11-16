using System.Web.Http;
using WebApiForTodoApp.Models;
using WebApiForTodoApp.Repository;
using WebApiForTodoApp.Service;

namespace WebApiForTodoApp.Controllers
{
	//[EnableCors("*", "*", "*")]
	public class TodoController : ApiController
	{
		private readonly ITodoRepository _repository;
		private readonly ITodoService _service;

		public TodoController(ITodoRepository repository, ITodoService service)
		{
			_repository = repository;
			_service = service;
		}

		public IHttpActionResult Get()
		{
			return Ok(_service.GetList());
		}

		public IHttpActionResult Post(Todo todo)
		{
			if (!_service.Create(todo))
				return NotFound();

			return Ok();
		}

		public IHttpActionResult Put(int id, Todo todo)
		{
			if (!_service.Edit(todo) && (todo != null || id != todo.Id))
				return NotFound();

			_service.Edit(todo);

			return Ok(todo);
		}

		public IHttpActionResult Delete(int id)
		{
			var existingTodo = _repository.GetById(id);
			if (existingTodo == null && _service.Remove(existingTodo))
				return NotFound();

			_service.Remove(existingTodo);

			return Ok(existingTodo);
		}
	}
}