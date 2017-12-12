using System.Collections.Generic;
using System.Linq;
using TodoRESTService.Models;

namespace TodoRESTService.Services
{
    public class TodoRepository : ITodoRepository
    {
        private List<TodoItem> _todoList;

		public TodoRepository()
		{
			_todoList = new List<TodoItem>();
		}


		public IEnumerable<TodoItem> All
        {
            get { return _todoList; }
        }

        public bool DoesItemExist(string id)
        {
            return _todoList.Any(item => item.ID == id);
        }

        public TodoItem Find(string id)
        {
            return _todoList.Where(item => item.ID == id).FirstOrDefault();
        }

        public void Insert(TodoItem item)
        {
            _todoList.Add(item);
        }

        public void Update(TodoItem item)
        {
            var todoItem = this.Find(item.ID);
            var index = _todoList.IndexOf(todoItem);
            _todoList.RemoveAt(index);
            _todoList.Insert(index, item);
        }

        public void Delete(string id)
        {
            _todoList.Remove(this.Find(id));
        }

		public void Clone(TodoItem item)
		{
			var todoItem = this.Find(item.ID);
			var clonedItem = item.Clone();
			_todoList.Add(clonedItem);
		}
    }
}
