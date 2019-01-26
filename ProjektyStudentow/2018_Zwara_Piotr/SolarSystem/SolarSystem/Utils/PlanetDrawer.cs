using System;
using System.Drawing;

using SolarSystem.Models;
using SolarSystem.Utils.Abstraction;

namespace SolarSystem.Utils
{
    public class PlanetDrawer : IControlsObserver
    {
        public DrawerState State { get; set; }

        public IPlanet Planet { get; private set; }
        public int ContainerWidth { get; private set; }
        public int ContainerHeght { get; private set; }
        public int Angle { get; private set; }

        public PlanetDrawer(IPlanet planet, int containerHeght, int containerWidth, int angle)
        {
            this.Planet = planet;
            this.ContainerHeght = containerHeght;
            this.ContainerWidth = containerWidth;
            this.Angle = angle;
            this.State = new RunningState(this);
        }

        public void Move()
        {
            (int x, int y) = this.State.GetNextLocation();
            this.Planet.Picture.Location = new Point(x, y);
        }

        public void AxisChanged(int containerHeigh, int containerWidth, int angle)
        {
            this.ContainerHeght = containerHeigh;
            this.ContainerWidth = containerWidth;
            this.Angle = angle;

            (int x, int y) = this.State.CalculateLocation();
            this.Planet.Picture.Location = new Point(x, y);
        }

        public void StateChanged(Type newState)
        {
            if (newState.IsSubclassOf(typeof(DrawerState)))
                this.State = (DrawerState)Activator.CreateInstance(newState, this.State);
        }
    }
}
