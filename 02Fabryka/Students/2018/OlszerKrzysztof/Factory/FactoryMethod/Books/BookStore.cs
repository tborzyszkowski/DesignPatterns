using System;

namespace FactoryMethod.Books
{
    public abstract class BookStore
    {
        public abstract Book createBook(string id);
        public Book read(string id)
        {
            Book book = createBook(id);
            String res = book.open();
            res += book.getName();
            res += book.getNoPages();
            Console.WriteLine(res);
            return book;
        }
    }
}
