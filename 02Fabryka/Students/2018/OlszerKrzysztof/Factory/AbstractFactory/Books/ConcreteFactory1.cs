namespace AbstractFactory.Books
{
    public class ConcreteFactory1 : AbstractFactory
    {
        private static ConcreteFactory1 instance;

        private ConcreteFactory1() { }

        public static ConcreteFactory1 getInstance()
        {
            if (instance == null)
                instance = new ConcreteFactory1();
            return instance;
        }

        public override AbstractMickiewicz createMickiewiczBook()
        {
            return new Sonety();
        }

        public override AbstractSlowacki createSlowackiBook()
        {
            return new Balladyna();
        }
    }
}
