using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        public IList<Product> Products { get; set; }
        //public IList<TodoList> Lists { get; set; }
        //public IList<TodoItem> Items { get; set; }
    }
}
