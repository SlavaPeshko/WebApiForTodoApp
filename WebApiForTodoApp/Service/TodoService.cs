using System;
using System.Collections.Generic;
using WebApiForTodoApp.Models;
using WebApiForTodoApp.Repository;

namespace WebApiForTodoApp.Service
{
	public class TodoService : ITodoService
	{
		private readonly ITodoRepository _repository;
		private readonly IValidationDictionary _validationDictionary;

		public TodoService(ITodoRepository repository, IValidationDictionary validationDictionary)
		{
			_repository = repository;
			_validationDictionary = validationDictionary;
		}

		public IEnumerable<Todo> GetList()
		{
			return _repository.GetAll();
		}

		public bool Create(Todo todo)
		{
			if (!ValidateTodo(todo))
				return false;

			try
			{
				_repository.Create(todo);
			}
			catch (Exception ex)
			{
				_validationDictionary.AddError(ex.Source, ex.Message);
			}

			return true;
		}

		public bool Remove(Todo todo)
		{
			try
			{
				_repository.Remove(todo);
			}
			catch (Exception ex)
			{
				_validationDictionary.AddError(ex.Source, ex.Message);
			}

			return true;
		}

		public bool Edit(Todo todo)
		{
			if (!ValidateTodo(todo))
				return false;

			try
			{
				_repository.Edit(todo);
			}
			catch (Exception ex)
			{
				_validationDictionary.AddError(ex.Source, ex.Message);
			}

			return true;
		}

		private bool ValidateTodo(Todo todo)
		{
			if (todo.Title.Trim().Length == 0)
				_validationDictionary.AddError("Title", "Title is required");
			if (todo.Project.Trim().Length == 0)
				_validationDictionary.AddError("Project", "Project is required");
			return _validationDictionary.IsValid;
		}
	}
}