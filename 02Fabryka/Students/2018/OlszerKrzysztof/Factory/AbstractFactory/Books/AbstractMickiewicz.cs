namespace AbstractFactory.Books
{
    public abstract class AbstractMickiewicz
    {
        public string Author;
        public string Title;
        public int NoPages;

        public abstract string read();
    }
}
