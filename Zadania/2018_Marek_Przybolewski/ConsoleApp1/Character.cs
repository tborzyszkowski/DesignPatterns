namespace ConsoleApp1
{
    public interface Character
    {
        int health { get; set; }
        Character copy();
    }
}