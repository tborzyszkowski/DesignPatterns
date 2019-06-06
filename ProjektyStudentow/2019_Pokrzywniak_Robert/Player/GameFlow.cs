using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
    public abstract class GameFlow
    {
        public abstract void Login();
        public abstract void ChosePlayer();
        public abstract void Donate();
        public abstract void Logout();

        public void Run()
        {
            Console.WriteLine("Welcome to the Game");
            Login();
            ChosePlayer();
            Donate();
            Logout();
            Console.ReadLine();
        }
    }
}
