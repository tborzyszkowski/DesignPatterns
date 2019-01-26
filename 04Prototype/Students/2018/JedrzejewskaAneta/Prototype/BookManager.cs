using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    class BookManager
    {
        private Dictionary<string, BookPrototype> books =
         new Dictionary<string, BookPrototype>();
        
        public BookPrototype this[string key]
        {
            get
            {
                return books[key];
            }
            set
            {
                books.Add(key, value);
            }
        }
    }
}
