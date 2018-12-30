using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;

using SolarSystem.Models;

namespace SolarSystem.Utils
{
    public class AstronomicalObjectConstructor
    {
        private static readonly Lazy<AstronomicalObjectConstructor> lazyIstance =
            new Lazy<AstronomicalObjectConstructor>(() => new AstronomicalObjectConstructor());

        private AstronomicalObjectConstructor() { }

        public static AstronomicalObjectConstructor Instance
        {
            get { return lazyIstance.Value; }
        }

        public SolarSystemObjects CreateSolarSystemObjects()
        {
            Star star = this.CreateStar();
            var starAdapter = new StarAdapter(star);
            IEnumerable<IPlanet> planets = this.CreatePlanets();

            var solarSystemObjects = new SolarSystemObjects();
            solarSystemObjects.Add(starAdapter);
            solarSystemObjects.AddRange(planets);

            return solarSystemObjects;
        }

        private Star CreateStar()
        {
            using (StreamReader file = File.OpenText(ConfigurationManager.AppSettings["SolarSystemDataFilePath"]))
            {
                dynamic solarSystemData = JObject.Parse(file.ReadToEnd());
                return new Star
                {
                    StarName = (string)solarSystemData.Star.Name,
                    Image = new PictureBox
                    {
                        Size = new Size(20, 20),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Image.FromFile((string)solarSystemData.Star.PicturePath)
                    }
                };
            }
        }

        private IEnumerable<IPlanet> CreatePlanets()
        {
            using (StreamReader file = File.OpenText(ConfigurationManager.AppSettings["SolarSystemDataFilePath"]))
            {
                dynamic solarSystemData = JObject.Parse(file.ReadToEnd());
                foreach (dynamic data in solarSystemData.Planets)
                {
                    yield return new PlanetBuilder()
                        .SetName((string)data.Name)
                        .SetPostion((int)data.Postion)
                        .SetOrbit((double)data.Speed, (double)data.Perihelion, (double)data.SemiMajorAxis, (double)data.Circuit, (double)data.Inclination)
                        .SetPicture(((string)data.PicturePath))
                        .Build();
                }
            }
        }
    }
}
