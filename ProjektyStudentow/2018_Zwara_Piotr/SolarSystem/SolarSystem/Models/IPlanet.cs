using System.Windows.Forms;

namespace SolarSystem.Models
{
    public interface IPlanet
    {
        int Postion { get; set; }

        string Name { get; set; }

        PictureBox Picture { get; set; }

        Orbit Orbit { get; set; }
    }
}
