namespace Adapter.Zad2
{
    public class SquirrelAdaptee
    {
        public string Name { get; private set; } = "Squirrel";

        public string Jump()
        {
            return $"{this.Name} is jumping form tree to tree";
        }
    }
}
