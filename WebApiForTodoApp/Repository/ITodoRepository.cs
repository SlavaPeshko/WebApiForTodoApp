using System.Linq;
using WebApiForTodoApp.Models;

namespace WebApiForTodoApp.Repository
{
	public interface ITodoRepository
	{
		IQueryable<Todo> GetAll();
		Todo GetById(int id);
		void Create(Todo item);
		void Remove(Todo item);
		void Edit(Todo item);
	}
}