using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    class CharacterFactory
    {
        public AbstractCharacter CreateCharacter(String character, int x, int y) {
            if (character == "Grass")
            {
                return new Grass(x, y);
            }
            else if (character == "Sheep")
            {
                return new Sheep(x, y);
            }
            else if (character == "Wolf")
            {
                return new Wolf(x, y);
            }

            else return null;
        }
    }
}
