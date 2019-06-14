using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builder1
{
    public class Ravastra1 : Builder1
    {
        public Ravastra1()
        {
            frigate = CreateNewShip();
        }
        public override Frigate1 CreateNewShip()
        {
            return new Frigate1() { Name = "Ravastra Skirmisher" };
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
            frigate.Race = "Fraction Vassari";
            return this;
        }
        public override Builder1 SetHp()
        {
            frigate.Hp = 740;
            return this;
        }
        public override Builder1 SetCost()
        {
            frigate.Cost = 420;
            return this;
        }
        public override Builder1 SetDmg()
        {
            frigate.Dmg = 12;
            return this;
        }
        public override Builder1 SetMainWeapon()
        {
            frigate.MainWeapon = "Pulse Gun";
            return this;
        }
        public override Builder1 SetShields()
        {
            frigate.Shields = 465;
            return this;
        }
    }
}

