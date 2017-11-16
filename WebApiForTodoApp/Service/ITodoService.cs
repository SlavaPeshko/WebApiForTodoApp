using System.Linq;
using WebApiForTodoApp.Models;

namespace WebApiForTodoApp.Service
{
	public interface ITodoService
	{
		IQueryable<Todo> GetAllTodos();
		bool CreateTodo(Todo todo);
		bool RemoveTodo(Todo todo);
		bool EditTodo(Todo todo);
	}
}