﻿namespace WebApiForTodoApp.Models
{
	public class Todo
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Project { get; set; }
		public string Title { get; set; }
		public bool IsCompleted { get; set; }
	}
}