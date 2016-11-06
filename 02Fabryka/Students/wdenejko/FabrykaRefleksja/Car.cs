namespace FabrykaRefleksja
{
    using System;
    using System.Collections.Generic;

    public abstract class Car
    {
        protected string Producent;
        protected string Model;
        protected double PojemnoscSilnika;
        protected List<string> Wlasciwosci = new List<string>();

        public void Produce()
        {
            Console.WriteLine($"Producent: {Producent}, Marka: {Model}, Pojemnosc: {PojemnoscSilnika}, Wlasciwosci:");
            foreach (var dd in Wlasciwosci)
            {
                Console.WriteLine(dd);
            }
        }
    }
}
