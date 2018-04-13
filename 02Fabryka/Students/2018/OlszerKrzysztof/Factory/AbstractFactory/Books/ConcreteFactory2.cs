namespace AbstractFactory.Books
{
    public class ConcreteFactory2 : AbstractFactory
    {
        private static ConcreteFactory2 instance;

        private ConcreteFactory2() { }

        public static ConcreteFactory2 getInstance()
        {
            if (instance == null)
                instance = new ConcreteFactory2();
            return instance;
        }

        public override AbstractMickiewicz createMickiewiczBook()
        {
            return new Tadeusz();
        }

        public override AbstractSlowacki createSlowackiBook()
        {
            return new Kordian();
        }
    }
}
