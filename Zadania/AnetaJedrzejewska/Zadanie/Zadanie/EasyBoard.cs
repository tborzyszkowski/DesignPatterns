using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    class EasyBoard : IBoard
    {

        List<AbstractCharacter> characters = new List<AbstractCharacter>();
        public void SetWolfs() {
            List<AbstractCharacter> characters = new List<AbstractCharacter>();
            characters.Add(new Wolf(1, 1, 10));
            characters.Add(new Wolf(1, 4, 10));
            characters.Add(new Wolf(1, 7, 10));
        }

        public void SetSheeps()
        {
            List<AbstractCharacter> characters = new List<AbstractCharacter>();
            characters.Add(new Sheep(0, 1, 5));
            characters.Add(new Sheep(0, 4, 5));
            characters.Add(new Sheep(0, 7, 5));
        }
        public void SetGrass()
        {
            List<AbstractCharacter> characters = new List<AbstractCharacter>();
            characters.Add(new Grass(0, 1, 5));
            characters.Add(new Grass(0, 4, 5));
            characters.Add(new Grass(0, 7, 5));
        }

        public List<AbstractCharacter> getList() {
            return characters;
        }
    }
}
