using System;

namespace Adapter.Zad2
{
    public class FlyingAnimalAdapter : IFlyingAnimal
    {
        private Func<string> TryToFly;

        public FlyingAnimalAdapter(SquirrelAdaptee adaptee)
        {
            this.TryToFly = adaptee.Jump;
        }

        public FlyingAnimalAdapter(PenguinAdaptee adaptee)
        {
            this.TryToFly = adaptee.Swim;
        }

        public void ChangeTryFy(Func<string> delegateFunc)
        {
            this.TryToFly = delegateFunc;
        }

        public string Fly()
        {
            return this.TryToFly();
        }
    }
}
