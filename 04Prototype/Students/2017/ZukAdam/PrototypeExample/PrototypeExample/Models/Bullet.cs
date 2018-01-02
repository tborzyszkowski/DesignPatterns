namespace PrototypeExample.Models
{
    public class Bullet
    {
        public int BulletSize { get; set; }

        public Bullet() { } // For serialization purposes

        public Bullet(int bulletSize)
        {
            this.BulletSize = bulletSize;
        }

        public override string ToString()
        {
            return string.Format("\n\t\tID: {0}\n\t\tBulletSize: {1}", this.GetHashCode(), this.BulletSize);
        }
    }
}
