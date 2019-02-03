using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    abstract class AbstractCharacter
    {
        protected int life;
        protected int xCoordinate;
        protected int yCoordinate;
        abstract public void Eat(AbstractCharacter character);
        //abstract public void Die();

        abstract public void Move(Direction direction);

        public int GetLife() {
            return life;
        }
    }
}
