using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Forest : IMap //Metoda fabrykująca
    {
        const GroundType goundType = GroundType.Bedding;
        const ItemType itemType = ItemType.Mushroom;
        int[ ] size = new int[2];
        Player player;
        Enemy enemy;

        public Forest(Player newPlayer)
        {
            size[0] = 100;
            size[1] = 100;
            player = newPlayer;
            enemy = new Enemy("DefaultName");
        }
        public void SetSize(int x, int y)
        {
            size[0] = x;
            size[1] = y;
        }
        public void PutAnotherEnemy()
        {
            enemy = new Enemy("DeafaultName");
        }
        public override string ToString()
        {
            return "          Type of map: forest" + ", width of map: " + size[0] + ", height of map: " + size[1];
        }
    }
}
