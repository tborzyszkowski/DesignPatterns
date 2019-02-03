namespace ConsoleApp1
{
    public class Grass : Character
    {
        public int health { get; set; }

        public Character copy()
        {
            Grass newGrass = new Grass();
            newGrass.health = health/2;
            return newGrass;
        }

        public Grass()
        {
            health = 40;
        }
    }
}