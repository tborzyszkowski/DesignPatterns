using System.Collections.Generic;

namespace PrototypeExample.Models
{
    public class Turret
    {
        public int Length { get; set; }

        public List<Bullet> Bullets { get; set; }

        public override string ToString()
        {
            var info = string.Format("\n\tID: {0}\n\tLength: {1}\n\tBullets:", this.GetHashCode(), this.Length);

            foreach (var bullet in this.Bullets)
            {
                info += bullet;
            }

            return info;
        }
    }
}
