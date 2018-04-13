namespace AbstractFactory.Books
{
    class Kordian : AbstractSlowacki
    {
        public Kordian()
        {
            Author = "Juliusz Slowacki";
            Title = "Kordian";
            NoPages = 200;
        }

        public override string read()
        {
            return Author + " " + Title + " " + NoPages;
        }
    }
}
