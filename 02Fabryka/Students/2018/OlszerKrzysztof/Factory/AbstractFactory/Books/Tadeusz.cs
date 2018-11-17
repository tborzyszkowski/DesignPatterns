namespace AbstractFactory.Books
{
    class Tadeusz : AbstractMickiewicz
    {
        public Tadeusz()
        {
            Author = "Adam Mickiewicz";
            Title = "Pan Tadeusz";
            NoPages = 300;
        }

        public override string read()
        {
            return Author + " " + Title + " " + NoPages;
        }
    }
}
