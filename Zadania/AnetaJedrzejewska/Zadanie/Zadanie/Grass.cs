using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie
{
    class Grass : AbstractCharacter
    {

        public Grass(int x, int y, int l) {

            xCoordinate = x;
            yCoordinate = y;
            life = l;
        }

        public override void Eat(AbstractCharacter character) {
            Console.WriteLine("Grass can't eat");
        }

        public override void Move(Direction direction)
        {
            Console.WriteLine("Grass can't move");
        }

    }
}
