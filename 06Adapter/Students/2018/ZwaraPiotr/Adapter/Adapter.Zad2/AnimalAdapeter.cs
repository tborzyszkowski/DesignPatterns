using System;

namespace Adapter.Zad2
{
    public class AnimalAdapeter : AnimalAdaptee
    {
        public Func<string> TryFly;

        public AnimalAdapeter(AnimalAdaptee adaptee)
        {
            this.TryFly = () => $"{adaptee.Name} is learning to fly";
        }

        public AnimalAdapeter(PenguinTarget target)
        {
            this.TryFly = target.Swim;
        }

        public void ChangeRequest(Func<string> delegateFunc)
        {
            this.TryFly = delegateFunc;
        }
    }
}
