using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builder1
{
    public class Cobalt1 : Builder1
    {
        public Cobalt1()
        {
            frigate = CreateNewShip();
        }
        public override Frigate1 CreateNewShip()
        {
            return new Frigate1() { Name = "Cobalt Light Frigate" };
        }
        public override Builder1 SetModel()
        {
            frigate.Model = "Frigate Type Light";
            return this;
        }
        public override Builder1 SetArmor()
        {
            frigate.Armor = "Medium";
            return this;
        }
        public override Builder1 SetRace()
        {
            frigate.Race = "Fraction TEC";
            return this;
        }
        public override Builder1 SetHp()
        {
            frigate.Hp = 635;
            return this;
        }
        public override Builder1 SetCost()
        {
            frigate.Cost = 300;
            return this;
        }
        public override Builder1 SetDmg()
        {
            frigate.Dmg = 10;
            return this;
        }
        public override Builder1 SetMainWeapon()
        {
            frigate.MainWeapon = "Laser";
            return this;
        }
        public override Builder1 SetShields()
        {
            frigate.Shields = 370;
            return this;
        }
    }
}
