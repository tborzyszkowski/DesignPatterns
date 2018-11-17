namespace FactoryMethod.Books
{
    public abstract class Book
    {
        protected string Author;
        protected string Title;
        protected int NoPages;

        public string open() => "Book.open()";
        public string getName() => Author + " " + Title;
        public int getNoPages() => NoPages;
    }
}
