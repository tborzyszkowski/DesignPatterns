namespace ConsoleApp1
{
    public interface GameObserver
    {
        void MultipleObject(Character character);

        void AddHealth(Character character);

        void EatCharacter(Character characterEated, Character characterWhichEat);

        void DeacreaseHealth(Character character);
    }
}