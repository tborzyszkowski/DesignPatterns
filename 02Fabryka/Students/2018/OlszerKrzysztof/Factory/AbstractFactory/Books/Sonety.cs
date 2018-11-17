namespace AbstractFactory.Books
{
    class Sonety : AbstractMickiewicz
    {
        public Sonety()
        {
            Author = "Adam Mickiewicz";
            Title = "Sonety krymskie";
            NoPages = 300;
        }

        public override string read()
        {
            return Author + " " + Title + " " + NoPages;
        }
    }
}
