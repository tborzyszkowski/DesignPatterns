using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fabrykaRejestrująca.apc;
using fabrykaRejestrująca.bwp;
using fabrykaRejestrująca.czolg;
using fabrykaRejestrująca.dziala;

namespace fabrykaRejestrująca
{
    class fabryka
    {
        private static fabryka instancja;
        protected fabryka() { }

        public static fabryka dajFabryke()
        {
            if (instancja == null)
            {
                instancja = new fabryka();
            }
            return instancja;
        }

        private Dictionary<string, Type> typy = new Dictionary<string, Type>();

        public void dodajDoSlownika(string nazwa, Type typ) 
        {
            typy.Add(nazwa, typ);
        }

        public czolg.czolg zrobCzolg(string nazwa)
        {
            Type czolg;
            if (typy.ContainsKey(nazwa))
            {
                czolg = typy[nazwa];
                return Activator.CreateInstance(czolg) as czolg.czolg;
            }
            else
                return null;
        }

        public dziala.dziala zrobDzialo(string nazwa)
        {
            Type dzialo;
            if (typy.ContainsKey(nazwa))
            {
                dzialo = typy[nazwa];
                return Activator.CreateInstance(dzialo) as dziala.dziala;
            }
            else
                return null;
        }

        public bwp.bwp zrobBewupa(string nazwa)
        {
            Type bewup;
            if (typy.ContainsKey(nazwa))
            {
                bewup = typy[nazwa];
                return Activator.CreateInstance(bewup) as bwp.bwp;
            }
            else
                return null;
        }

        public apc.apc zrobTransporter(string nazwa)
        {
            Type apecetka;
            if (typy.ContainsKey(nazwa))
            {
                apecetka = typy[nazwa];
                return Activator.CreateInstance(apecetka) as apc.apc;
            }
            else
                return null;
        }

    }
}
