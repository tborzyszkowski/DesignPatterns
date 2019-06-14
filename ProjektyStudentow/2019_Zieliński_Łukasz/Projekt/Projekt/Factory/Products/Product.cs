using System;
using Projekt.Observer;
using Projekt.Prototype;

namespace Projekt.Factory.Products
{
    public abstract class Product : PrototypeItems, InterfaceProducts
    {
        public enum TopColor
        {
            Gray,
            Off_White,
            Pure,
            Natural,
            Tobacco,
            Cacao,
            Nutty
        }
        public enum LegsPillowColor
        {
            Black,
            White,
            Inax
        }
        public TopColor color1 { get;  set; }
        public LegsPillowColor color2 { get;  set; }
        public string name { get;  set; }
        public int height { get;  set; }
        public int width { get;  set; }
        public int length { get;  set; }
        public int cost { get; set; }
        //public abstract void Item();
        //public abstract decimal Value();

        public override PrototypeItems Clone()
        {
            //Console.WriteLine("Zamówiono: "+x+" produktów: "+name );
            //for (int i = 0; i < x; i++)
            //{
            //    return this.MemberwiseClone() as Product;
            //}
            return this.MemberwiseClone() as Product;
        }
        public void Decoration()
        {
            Console.WriteLine(name+ " został powoskowany.. \n");
        }
    }
    

}