using System;

namespace SolarSystem.Utils.Abstraction
{
    public interface IObserverSubject
    {
        void NotifyAxisChanged();
        void NotifyStateChanged(Type newState);
    }
}
