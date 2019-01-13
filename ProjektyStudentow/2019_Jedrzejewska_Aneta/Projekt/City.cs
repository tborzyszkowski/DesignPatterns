using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class City : IMap //Metoda fabrykująca
    {
        const GroundType groundType = GroundType.Concrete;
        const ItemType itemType = ItemType.Star;
        int[ ] size = new int[2];
        Player player;
        Enemy enemy;

        public City(Player newPlayer)
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
            return "          Type of map: city" + ", width of map: " + size[0] + ", height of map: " + size[1];
        }
    }
}
