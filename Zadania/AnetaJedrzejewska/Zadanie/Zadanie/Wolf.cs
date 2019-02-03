using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    class Wolf : AbstractCharacter
    {
        public Wolf(int x, int y, int l)
        {
            xCoordinate = x;
            yCoordinate = y;
            life = l;
        }
        public override void Eat(AbstractCharacter character)
        {
            Sheep sheep = (Sheep)character;
            life += sheep.GetLife() / 2;
        }

        public override void Move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
