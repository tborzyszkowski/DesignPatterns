using System;

using SolarSystem.Models;

namespace SolarSystem.Utils
{
    public class RunningState : DrawerState
    {
        public RunningState(PlanetDrawer drawer)
        {
            this.Drawer = drawer;
            this.DrawStep = 0;
        }

        public RunningState(DrawerState state)
        {
            this.Drawer = state.Drawer;
            this.DrawStep = state.DrawStep;
        }

        public override (int, int) GetNextLocation()
        {
            this.NextStep();
            return this.CalculateLocation();
        }
    }

    public class StopedState : DrawerState
    {
        public StopedState(PlanetDrawer drawer)
        {
            this.Drawer = drawer;
            this.DrawStep = 0;
        }

        public StopedState(DrawerState state)
        {
            this.Drawer = state.Drawer;
            this.DrawStep = state.DrawStep;
        }

        public override (int, int) GetNextLocation()
        {
            if (this.DrawStep == 0)
                return (this.Drawer.Planet.Picture.Location.X, this.Drawer.Planet.Picture.Location.Y);

            this.DrawStep = 0;
            return this.CalculateLocation();
        }
    }

    public class PausedState : DrawerState
    {
        public PausedState(PlanetDrawer drawer)
        {
            this.Drawer = drawer;
            this.DrawStep = 0;
        }

        public PausedState(DrawerState state)
        {
            this.Drawer = state.Drawer;
            this.DrawStep = state.DrawStep;
        }

        public override (int, int) GetNextLocation()
        {
            return (this.Drawer.Planet.Picture.Location.X, this.Drawer.Planet.Picture.Location.Y);
        }
    }

    public abstract class DrawerState
    {
        public PlanetDrawer Drawer { get; protected set; }
        public double DrawStep { get; protected set; }

        public abstract (int, int) GetNextLocation();

        #region Methods

        public void NextStep()
        {
            Orbit orbit = this.Drawer.Planet.Orbit;

            if (orbit == null)
                return;

            this.DrawStep += 30 / orbit.Circuit * orbit.Speed;
            if (this.DrawStep > 360)
                this.DrawStep -= 360;
        }

        public (int, int) CalculateLocation()
        {
            /*
             * X(t) = Xc + a*cos(t)*cos(fi) - b*sin(t)*sin(fi)
             * Y(t) = Yc + a*cos(t)*cos(fi) + b*sin(t)*sin(fi)
             */

            int containerWidth = this.Drawer.ContainerWidth;
            int containerHeght = this.Drawer.ContainerHeght;
            int angle = this.Drawer.Angle;

            Orbit orbit = this.Drawer.Planet.Orbit;

            if (orbit == null)
                return (containerWidth / 2, containerHeght / 2);

            this.DrawStep += 30 / orbit.Circuit * orbit.Speed;
            if (this.DrawStep > 360)
                this.DrawStep -= 360;

            double planetAngle = this.DrawStep * Math.PI / 180;
            double planetAngleSin = Math.Sin(planetAngle);
            double palnetAngleCos = Math.Cos(planetAngle);

            int size = Math.Min(containerHeght, this.Drawer.ContainerWidth);
            double shift = this.Drawer.Planet.Postion * size / 30;

            int x = (int)(containerWidth / 2
                + (orbit.SemiMajorAxis - orbit.Perihelion) / 10000 * size / 7.5
                + (orbit.SemiMajorAxis / 10000 * size / 7.0 + shift) * planetAngleSin);

            int y = (int)((orbit.SecondAxis / 10000 * size / 7.0 + shift) * this.CalculateInclination() * palnetAngleCos);

            y = angle - orbit.Inclination <= 180
                ? y + containerHeght / 2
                : containerHeght - (containerHeght / 2 + y);

            return (x, y);
        }

        public double CalculateInclination()
        {
            double factor = 1;
            double angleModulo = (this.Drawer.Angle - this.Drawer.Planet.Orbit.Inclination) % 180;

            if (angleModulo == 0)
                factor = 0.001;
            else if (angleModulo <= 90)
                factor = angleModulo / 90.0;
            else
                factor = (180 - angleModulo) / 90.0;
            return factor;
        }

        #endregion Methods
    }
}
