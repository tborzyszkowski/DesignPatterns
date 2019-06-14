using System;
using Builder.Frigates;

namespace Builder.Abstract
{
    // zestaw nazwanych stałych, lista modułów wyliczających
    public enum Fraction
    {
        TEC,
        Advent,
        Vassari
    }
    public enum Armor
    {
        Light,
        Medium,
        Heavy,
        Very_Heavy,
        Capital
    }
    // sygnatury 
    public interface Ships
    {
        Fraction Race { get;}
        Armor Armored { get;}
        string Name { get;}
        int Hp { get;}
        int Cost { get;}
        int Dmg { get;}
        string MainWeapon { get;}
        int Shields { get;}

    }
}