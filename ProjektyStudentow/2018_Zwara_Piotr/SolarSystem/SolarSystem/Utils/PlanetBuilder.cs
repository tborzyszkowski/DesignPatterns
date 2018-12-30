using System;
using System.Drawing;
using System.Windows.Forms;

using SolarSystem.Models;
using SolarSystem.Utils.Abstraction;

namespace SolarSystem.Utils
{
    public class PlanetBuilder : IPlanetBuilder
    {
        private readonly Planet planet;

        public PlanetBuilder()
        {
            this.planet = new Planet();
        }

        public IPlanetBuilder SetName(string name)
        {
            this.planet.Name = name;
            return this;
        }

        public IPlanetBuilder SetPostion(int postion)
        {
            this.planet.Postion = postion;
            return this;
        }

        public IPlanetBuilder SetOrbit(
            double speed, double perihelion, double semiMajorAxis, double circuit, double inclination)
        {
            this.planet.Orbit = new Orbit
            {
                Speed = speed,
                Perihelion = perihelion,
                SemiMajorAxis = semiMajorAxis,
                Circuit = circuit,
                Inclination = inclination
            };
            return this;
        }

        public IPlanetBuilder SetPicture(string imagePath)
        {
            this.planet.Picture = new PictureBox
            {
                Size = new Size(20, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(imagePath),
            };
            return this;
        }

        public IPlanet Build()
        {
            if (this.planet.Orbit == null)
                throw new NullReferenceException("Planet orbit cannot be null");

            if (this.planet.Picture == null)
                throw new NullReferenceException("Planet picture cannot be null");

            return this.planet;
        }
    }
}
