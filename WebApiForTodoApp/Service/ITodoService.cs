using System.Collections.Generic;
using WebApiForTodoApp.Models;

namespace WebApiForTodoApp.Service
{
	public interface ITodoService
	{
		IEnumerable<Todo> GetList();
		bool Create(Todo todo);
		bool Remove(Todo todo);
		bool Edit(Todo todo);
	}
}