using Newtonsoft.Json;
using Player.Models;
using Player.Services;
using Server;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player
{
    public class Game : GameFlow
    {
        readonly ConnectionService _connectionService;
        readonly ServerEngine _serverEngine;
        private Me _friend;
        private Me _me;
        public Game()
        {
            _connectionService = new ConnectionService();
            _serverEngine = ServerEngine.Instance;
        }
        public override void Login()
        {
            Console.WriteLine("Please type your desired name:");
            var name = Console.ReadLine();
            _connectionService.Create(name);
            _connectionService.SetConnectionStrategy(new ConnectionLogin());
            _connectionService.Run();
            _me = _connectionService.GetMe();
            Console.WriteLine("Hello " + _me.Name);
            Console.WriteLine("You have " + _me.Money + " zł");
        }
        public override void ChosePlayer()
        {
            Console.WriteLine("Type name of player you know:");
            var name = Console.ReadLine();
            _friend = JsonConvert.DeserializeObject<Me>(_serverEngine.FindPlayerbyName(name));
            if(_friend == null)
            {
                Console.WriteLine("We are sorry your friend doesn't exist");
                return;
            }
            Console.WriteLine("Your friend has "+_friend.Money+" zł");
        }
        public override void Donate()
        {
            if (_friend == null)
                return;

            Console.WriteLine("Would you like to donate your friend all your money?:");
            var decision = Console.ReadLine();
            while(decision != "YES" && decision != "N0")
            {
                Console.WriteLine("PLEASE TYPE CORRECT ANSWER!");
                decision = Console.ReadLine();
            }

            if(decision == "NO")
            {
                Console.WriteLine("Understandable, have a nice day");
                return;
            }
            var response = _serverEngine.DonateMoney(_me.Name, _friend.Name);
            if (response.StartsWith("ERROR"))
            {
                Console.WriteLine(response);
                return;
            }
            var (me, friend) = JsonConvert.DeserializeObject<(Me,Me)>(response);
            Console.WriteLine("You "+me.Name+", have now "+me.Money+ " zł");
            Console.WriteLine("Your friend " + friend.Name + ", has now " + friend.Money + " zł");
        }
        public override void Logout()
        {
            _connectionService.SetConnectionStrategy(new ConnectionLogout());
            _connectionService.Run();
            Console.WriteLine("Thank you for participating in this experiment");
            Console.WriteLine("You have been successfully logged out");
        }
    }
}
