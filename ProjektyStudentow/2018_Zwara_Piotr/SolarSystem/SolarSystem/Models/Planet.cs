using System.Windows.Forms;

namespace SolarSystem.Models
{
    public class Planet : IPlanet
    {
        public int Postion { get; set; }

        public string Name { get; set; }

        public PictureBox Picture { get; set; }

        public Orbit Orbit { get; set; }
    }
}
