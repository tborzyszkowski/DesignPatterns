using System;

namespace AbstractFactory
{
    public static class Program
    {
        public static void Main()
        {
            /*Books.AbstractFactory af1 = new ConcreteFactory1();
            AbstractMickiewicz am1 = af1.createMickiewiczBook();

            Books.AbstractFactory af2 = new ConcreteFactory2();
            AbstractSlowacki as1 = af2.createSlowackiBook();

            Console.WriteLine(am1.Author + " " + am1.Title);

            Console.WriteLine(as1.Author + " " + as1.Title);

            Cars.AbstractFactory af1 = new Cars.ConcreteFactory1();
            Cars.AbstractFord ford = af1.createFord();

            Console.WriteLine(ford.drive());

            Tanks.AbstractFactory af = new Tanks.ConcreteFactory1();
            Tanks.AbstractGerman germ = af.createGermanTank();*/

            Books.AbstractFactory abstractFactory = Books.ConcreteFactory1.getInstance();
            Books.AbstractMickiewicz abstractMickiewicz = abstractFactory.createMickiewiczBook();


            Console.WriteLine(abstractMickiewicz.Title);


            Console.ReadLine();
        }
    }
}
