using System.Collections.Generic;
using System.Data.Entity;
using WebApiForTodoApp.Models;

namespace WebApiForTodoApp.Context
{
	public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			var todos = new List<Todo>()
			{
				new Todo()
				{
					Id = 1,
					UserId = 1,
					Title = "delectus aut autem",
					Project = "Project A",
					IsCompleted = false,
				},
				new Todo()
				{
					Id = 2,
					UserId = 1,
					Project = "Project B",
					Title = "quis ut nam facilis et officia qui",
					IsCompleted = true,
				},
				new Todo()
				{
					Id = 3,
					UserId = 2,
					Project = "Project C",
					Title = "fugiat veniam minus",
					IsCompleted = false,
				},
				new Todo()
				{
					Id = 4,
					UserId = 2,
					Project = "Project D",
					Title = "et porro tempora",
					IsCompleted = false,
				},
			};

			foreach (var todo in todos)
			{
				context.Todos.Add(todo);
			}
			context.SaveChanges();
			base.Seed(context);
		}
	}
}