using System;

namespace SolarSystem.Models
{
    public class Orbit
    {
        /// <summary>
        /// Średnia prędkość obiektu przesuwającego się po orbicie
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Najmniejsza odległość od centralnej gwiazdy
        /// </summary>
        public double Perihelion { get; set; }

        /// <summary>
        /// "Półoś wielka" - średnia odległość od centralnej gwiazdy
        /// </summary>
        public double SemiMajorAxis { get; set; }

        /// <summary>
        /// Obwód orbity
        /// </summary>
        public double Circuit { get; set; }

        /// <summary>
        /// Nachylenie
        /// </summary>
        public double Inclination { get; set; }

        #region Calculated Values

        public double SecondAxis
        {
            get
            {
                if (!this.secondAxis.HasValue)
                    this.secondAxis = this.CalculateSecondAxis();
                return this.secondAxis.Value;
            }
        }

        private double? secondAxis = null;

        private double CalculateSecondAxis()
        {
            /*
             * obliczanie drugiej półosi elipsy według przekształconego wzoru na obwód elipsy
             * 0 = 2.25*a^2 + 3.5*a*b + 2.25*b^2 - (3*a*Obwód) / PI + Obwód^2 / PI ^2
             */

            double delta = Math.Pow((3.5 * this.SemiMajorAxis - (3 * this.Circuit) / Math.PI), 2)
                - 4 * 2.25 * (2.25 * Math.Pow(this.SemiMajorAxis, 2) - 3 * this.SemiMajorAxis * (this.Circuit / Math.PI) + Math.Pow(this.Circuit / Math.PI, 2));
            double result = (float)((-(3.5 * this.SemiMajorAxis - (3 * this.Circuit) / Math.PI) + Math.Sqrt(delta)) / 4.5);
            return result;
        }

        #endregion Calculated Values
    }
}
