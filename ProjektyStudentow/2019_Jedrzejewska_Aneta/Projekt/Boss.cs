using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Boss : IBoss //Adapter, Dependency Injection
    {
        Enemy enemyAdaptee;

        public Boss(Enemy enemy)
        {
            enemyAdaptee = enemy;
        }

        public void GetExtraHealth()
        {
            enemyAdaptee.SetHealth(enemyAdaptee.GetHealth() + 50);
        }
    }
}
