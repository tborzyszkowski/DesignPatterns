using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tworzymy prototypy i ustalamy ich stany
            BookTwo onePrototype = new BookTwo();
            onePrototype.objOne.Name = "First book";
            onePrototype.objOne.Type = "horror";
            onePrototype.Publishing.Name = "Operon";
            onePrototype.Publishing.City = "Gdansk";

            BookTwo twoPrototype = new BookTwo();
            twoPrototype = onePrototype.DeepCopy();


            if (Object.ReferenceEquals(onePrototype.objOne, twoPrototype.objOne))
                Console.WriteLine("Referencje odwołują się do tego samego obiektu");
            else
                Console.WriteLine("Referencje NIE odwołują się do tego samego obiektu");
 

            //Console.WriteLine("Oryginalne obiekty: ");
            //Console.WriteLine("Name: {0}, Type: {1}, Publishing name: {2}, City: {3}", 
            //                onePrototype.Name.ToString(), 
            //                onePrototype.Type.ToString(), 
            //                onePrototype.Publishing.Name.ToString(), 
            //                onePrototype.Publishing.City.ToString());

            //Console.WriteLine("Klonowanie głębiokie: ");
            //Console.WriteLine("Name: {0}, Type: {1}, Publishing name: {2}, City: {3}",
            //                twoPrototype.Name.ToString(),
            //                twoPrototype.Type.ToString(),
            //                twoPrototype.Publishing.Name.ToString(),
            //                twoPrototype.Publishing.City.ToString());



            //// Tworzymy skolonowane produkty
            //BookOne[] one = new BookOne[10];
            //for (int i = 0; i < one.Length; i++)
            //{
            //    one[i] = onePrototype.Clone() as BookOne;
            //    one[i].Name = one[i].Name + " " + i;

            //    Console.WriteLine("Name: " + one[i].Name + ", Type: " + one[i].Type);
            //}

            //BookTwo[] two = new BookTwo[10];
            //for (int i = 0; i < two.Length; i++)
            //{
            //    two[i] = twoPrototype.Clone() as BookTwo;
            //    two[i].Name = two[i].Name + " " + i;

            //    Console.WriteLine("Name: " + two[i].Name + ", Type: " + two[i].Type);
            //}
            Console.ReadKey();

        }
    }
}
