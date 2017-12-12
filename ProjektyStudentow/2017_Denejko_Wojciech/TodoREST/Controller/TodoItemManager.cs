using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoREST
{
	public class TodoItemManager
	{
		IRestService restService;

		// Fasada
		public TodoItemManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<TodoItem>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		public Task SaveTaskAsync (TodoItem item, bool isNewItem = false)
		{
			return restService.SaveTodoItemAsync (item, isNewItem);
		}

		public Task DeleteTaskAsync (TodoItem item)
		{
			return restService.DeleteTodoItemAsync (item.ID);
		}

		// prototyp
		public Task CloneTaskAsync(TodoItem item)
		{
			return restService.CloneTodoItemAsync(item);
		}
	}
}
