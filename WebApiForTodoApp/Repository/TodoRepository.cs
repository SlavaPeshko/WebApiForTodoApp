using System;
using System.Linq;
using WebApiForTodoApp.Context;
using WebApiForTodoApp.Models;
using System.Data.Entity;

namespace WebApiForTodoApp.Repository
{
	public class TodoRepository : ITodoRepository, IDisposable
	{
		private readonly DatabaseContext _context;
		private bool _disposed = false;

		public TodoRepository(DatabaseContext context)
		{
			_context = context;
		}

		public IQueryable<Todo> GetAll()
		{
			return _context.Todos;
		}

		public Todo GetById(int id)
		{
			return _context.Todos.Find(id);
		}

		public void Create(Todo item)
		{
			_context.Todos.Add(item);
			_context.SaveChanges();
		}

		public void Remove(Todo item)
		{
			_context.Todos.Remove(item);
			_context.SaveChanges();
		}

		public void Edit(Todo item)
		{
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this._disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}