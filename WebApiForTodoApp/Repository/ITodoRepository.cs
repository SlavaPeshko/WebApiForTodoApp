using System.Collections.Generic;
using WebApiForTodoApp.Models;

namespace WebApiForTodoApp.Repository
{
	public interface ITodoRepository
	{
		IEnumerable<Todo> GetAll();
		Todo GetById(int id);
		Todo Create(Todo item);
		int Remove(Todo item);
		int Edit(Todo item);
	}
}