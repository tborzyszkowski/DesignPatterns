namespace AbstractFactory.Books
{
    class Balladyna : AbstractSlowacki
    {
        public Balladyna()
        {
            Author = "Juliusz Slowacki";
            Title = "Balladyna";
            NoPages = 200;
        }
        
        public override string read()
        {
            return Author + " " + Title + " " + NoPages;
        }
    }
}
