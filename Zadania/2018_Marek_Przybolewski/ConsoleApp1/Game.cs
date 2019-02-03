using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        private Map map = Map.MapInstance;

        private List<GameObserver> gameObservers = new List<GameObserver>();

        private bool isFinishedState;

        public void addGameObserver(GameObserver instance)
        {
            gameObservers.Add(instance);
        }

        public Game()
        {
            map.GenerateMap();

            StartGame();
        }

        public void StartGame()
        {
            while (!isFinishedState)
            {
                MakeMove();
                DeacreaseHealth();
            }
        }

        private void DeacreaseHealth()
        {
            foreach (var character in Map.MapInstance.Fields)
            {
                foreach (var observer in gameObservers)
                {
                    observer.DeacreaseHealth(character);
                }
            }
        }

        private void MakeMove()
        {
            foreach (var character in Map.MapInstance.Fields)
            {
                if (character.GetType() == typeof(Wolf) || character.GetType() == typeof(Sheep))
                {
                    //move
                    //check what was on this fields
                    //eat 
                    var eatedCharacter = Map.MapInstance.GetNextField();

                    foreach (var observer in gameObservers)
                    {
                        observer.EatCharacter(eatedCharacter, character);
                    }

                    if (character.health > 500)
                    {
                        foreach (var gameObserver in gameObservers)
                        {
                            gameObserver.MultipleObject(character);
                        }
                    }
                }
            }
        }
    }
}
