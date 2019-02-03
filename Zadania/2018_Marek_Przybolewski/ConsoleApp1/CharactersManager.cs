namespace ConsoleApp1
{
    public class CharactersManager : GameObserver
    {
        public void AddHealth(Character character)
        {
            character.health += 10;
        }

        public void EatCharacter(Character characterEated, Character characterWhichEat)
        {
            characterWhichEat.health += characterEated.health / 2;
        }

        public void DeacreaseHealth(Character character)
        {
            if (character.GetType() == typeof(Grass))
            {
                character.health += 10;
            }
            else
            {
                character.health -= 10;
            }
        }

        public void MultipleObject(Character character)
        {
            Map.MapInstance.PutOnMap(character.copy());
        }

    }
}