namespace AbstractFactory.Books
{
    public abstract class AbstractSlowacki
    { 
        public string Author;
        public string Title;
        public int NoPages;

        public abstract string read();
    }
}
