using System;

namespace FactoryMethod.Tanks
{
    public abstract class TankStore
    {
        public abstract Tank createTank(string id);
        public Tank getInfo(string id)
        {
            Tank tank = createTank(id);
            String res = tank.prepare();
            res += tank.getName();
            res += tank.getNationality();
            res += tank.getAge();
            Console.WriteLine(res);
            return tank;
        }
    }
}
