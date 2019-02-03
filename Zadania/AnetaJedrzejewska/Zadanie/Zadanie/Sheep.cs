using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    class Sheep : AbstractCharacter
    {

        public Sheep(int x, int y, int l) {

            xCoordinate = x;
            yCoordinate = y;
            life = l;
        }
        public override void Eat(AbstractCharacter character)
        {
            Grass grass = (Grass)character;
            life += grass.GetLife() / 2;
        }

        public override void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

    }
}
