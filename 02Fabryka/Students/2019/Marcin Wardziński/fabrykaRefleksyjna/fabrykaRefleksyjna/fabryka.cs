using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using fabrykaRefleksyjna.czolg;
using fabrykaRefleksyjna.apc;
using fabrykaRefleksyjna.bwp;
using fabrykaRefleksyjna.dziala;

namespace fabrykaRefleksyjna
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

        public void twozenieSlownika()
        {
            var kompilacja = Assembly.GetExecutingAssembly();
            var czolgi = kompilacja.GetTypes().Where(t => t.IsSubclassOf(typeof(czolg.czolg)));
            var armaty = kompilacja.GetTypes().Where(t => t.IsSubclassOf(typeof(dziala.dziala)));
            var transportery = kompilacja.GetTypes().Where(t => t.IsSubclassOf(typeof(apc.apc)));
            var wozyBojowe = kompilacja.GetTypes().Where(t => t.IsSubclassOf(typeof(bwp.bwp)));

            foreach (var typ in czolgi) typy.Add(typ.Name, typ);
            foreach (var typ in armaty) typy.Add(typ.Name, typ);
            foreach (var typ in transportery) typy.Add(typ.Name, typ);
            foreach (var typ in wozyBojowe) typy.Add(typ.Name, typ);
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
