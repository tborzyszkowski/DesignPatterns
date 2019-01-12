using System;

using System.Windows.Forms;

namespace SolarSystem.Models
{
    public class StarAdapter : IPlanet
    {
        private readonly Star Adaptee;

        public StarAdapter(Star star)
        {
            this.Adaptee = star;
        }

        public int Postion { get; set; } = 0;

        public string Name
        {
            get { return this.Adaptee.StarName;  }
            set { this.Adaptee.StarName = value; }
        }

        public PictureBox Picture
        {
            get { return this.Adaptee.Image; }
            set { this.Adaptee.Image = value; }
        }

        public Orbit Orbit
        {
            get { return null;  }
            set { throw new Exception("Star doesn't have an orbit"); }
        }
    }
}
