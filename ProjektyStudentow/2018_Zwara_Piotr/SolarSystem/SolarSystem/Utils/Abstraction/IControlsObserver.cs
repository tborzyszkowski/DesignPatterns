using System;

namespace SolarSystem.Utils.Abstraction
{
    public interface IControlsObserver
    {
        void AxisChanged(int containerHeigh, int containerWidth, int angle);
        void StateChanged(Type newState);
    }
}
