using AbstractFactory.Factories;
using AbstractFactory.Model;
using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //---Fabryka Abstrakcyjna---
            Console.WriteLine("---Fabryka abstrakcyjna---");
            IQueryAbstractFactory goodQueryFactory = new GoodAbstractFactory();
            DbQuery goodQuery = new DbQuery(goodQueryFactory, new Good { Name = "Krakowska sucha" });
            Console.WriteLine(goodQuery.GetInsert());
            Console.WriteLine(goodQuery.GetSelect());

            IQueryAbstractFactory contractorQueryFactory = new ContractorAbstractFactory();
            DbQuery contractorQuery = new DbQuery(contractorQueryFactory, new Contractor { Name = "Atlas" });
            Console.WriteLine(contractorQuery.GetInsert());
            Console.WriteLine(contractorQuery.GetSelect());

            //---Metoda wytwórcza---
            Console.WriteLine("\n\n---Metoda wytwórcza---");
            IQueryFactory factory = new ContractorFactory();
            DbQuery db = new DbQuery(factory, new Contractor { Name = "M&H" });
            Console.WriteLine(db.GetInsert());
            Console.WriteLine(db.GetSelect());

            factory = new GoodFactory();
            db = new DbQuery(factory, new Good { Name = "Kaszanka" });
            Console.WriteLine(db.GetInsert());
            Console.WriteLine(db.GetSelect());


            //---Prosta Fabryka---
            Console.WriteLine("\n\n---Prosta fabryka---");
            DbQuery goodQuerySimple = new DbQuery(new Good { Name = "Mielonka" });
            Console.WriteLine(goodQuerySimple.GetInsert());
            Console.WriteLine(goodQuerySimple.GetSelect());
            goodQuerySimple = new DbQuery(new Contractor { Name = "Sonny" });
            Console.WriteLine(goodQuerySimple.GetInsert());
            Console.WriteLine(goodQuerySimple.GetSelect());


            Console.ReadKey();
        }
    }
}
