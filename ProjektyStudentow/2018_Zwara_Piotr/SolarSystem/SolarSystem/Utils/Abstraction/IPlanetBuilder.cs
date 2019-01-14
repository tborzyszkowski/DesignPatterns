using SolarSystem.Models;

namespace SolarSystem.Utils.Abstraction
{
    public interface IPlanetBuilder
    {
        IPlanetBuilder SetName(string name);
        IPlanetBuilder SetPostion(int postion);
        IPlanetBuilder SetPicture(string imagePath);
        IPlanetBuilder SetOrbit(
            double speed, double perihelion, double semiMajorAxis, double circuit, double inclination);
        IPlanet Build();
    }
}
