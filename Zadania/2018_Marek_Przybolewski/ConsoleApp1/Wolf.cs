namespace ConsoleApp1
{
    public class Wolf : Character
    {
        public int health { get; set; }

        public Character copy()
        {
            Wolf newWolf = new Wolf();
            newWolf.health = health/2;
            return newWolf;
        }

        public Wolf()
        {
            health = 75;
        }
    }
}