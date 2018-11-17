using System;

namespace FactoryMethod.Tanks
{
    public abstract class Tank
    {
        protected string Name;
        protected string Nationality;
        protected DateTime Production;

        public string prepare() => "Tank.prepare()";
        public string getName() => Name;
        public string getNationality() => Nationality;
        public int getAge() => DateTime.Now.Year - Production.Year;
    }
}
