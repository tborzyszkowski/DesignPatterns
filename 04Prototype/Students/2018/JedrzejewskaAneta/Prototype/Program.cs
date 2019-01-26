using System;
using System.Drawing;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            BookManager bookManager = new BookManager();
            
            bookManager["first"] = new Book(100, Color.Blue, "First book");
            bookManager["second"] = new Book(250, Color.Brown, "Second book");
            bookManager["third"] = new Book(345, Color.Coral, "Third book");
            
            Book book1 = bookManager["first"].Duplicate() as Book;
            Book book2 = bookManager["second"].Duplicate() as Book;
            Book book3 = bookManager["third"].Duplicate() as Book;

            book1.SetColor(Color.Black);
            book2.SetPages(2000);
            book3.SetTitle("New third book");
            Console.WriteLine();

            Console.WriteLine("First book: " + bookManager["first"].ToString());
            Console.WriteLine("Duplicated first book with changed color: " + book1.ToString());
            Console.WriteLine();

            Console.WriteLine("Second book: " + bookManager["second"].ToString());
            Console.WriteLine("Duplicated second book with changed pages: " + book2.ToString());
            Console.WriteLine();

            Console.WriteLine("Third book: " + bookManager["third"].ToString());
            Console.WriteLine("Duplicated third book with changed color: " + book3.ToString());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
