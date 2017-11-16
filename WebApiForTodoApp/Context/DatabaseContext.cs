using System.Data.Entity;
using WebApiForTodoApp.Models;

namespace WebApiForTodoApp.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("DefaultConnection") { }

		public DbSet<Todo> Todos { get; set; }
	}
}