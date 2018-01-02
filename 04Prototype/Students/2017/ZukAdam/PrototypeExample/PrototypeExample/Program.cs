using PrototypeExample.Models;
using PrototypeExample.Utils;
using System;
using System.Collections.Generic;

namespace PrototypeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log("Shallow copy test");

            var tank = new Tank
            {
                Name = "M4 Sherman",
                Height = 12,
                Length = 5,
                Speed = 30,
                Width = 8,
                Turret = new Turret
                {
                    Length = 7,
                    Bullets = new List<Bullet>
                    {
                        new Bullet(2),
                        new Bullet(2),
                        new Bullet(2)
                    }
                }
            };
            tank.PrintInfo();

            var shallowClone = tank.ShallowClone();
            shallowClone.PrintInfo();


            Logger.Log("Deep copy test");

            tank.PrintInfo();

            var deepClone = tank.DeepClone();
            deepClone.PrintInfo();

            Console.ReadKey();
        }
    }
}