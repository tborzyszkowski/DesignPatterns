using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Controllers
{
    public sealed class PlayerController
    {
        private static Lazy<PlayerController> lazy = new Lazy<PlayerController>(() => new PlayerController());
        public static PlayerController Instance { get { return lazy.Value; } set { lazy = new Lazy<PlayerController>(() => value); } }

        readonly Player _playerPrototype;
        List<Player> _players;
        private PlayerController()
        {
            _playerPrototype = new Player();
            _players = new List<Player>();
            AddBots();
        }
        public Player LogIn(string name)
        {
            var player = _playerPrototype.ShallowCopy();
            player.Name = name;
            player.Money = 1;
            _players.Add(player);
            return player;
        }
        public void LogOut(Player player)
        {
            _players.RemoveAll(x => x.Name == player.Name);
        }
        private void AddBots()
        {
            var player1 = new Player()
            {
                Name = "Robert",
                Money = 0
            };
            var player2 = new Player()
            {
                Name = "Barbara",
                Money = 2
            };
            _players.Add(player1);
            _players.Add(player2);
        }
        public Player FindPlayerByName(string name)
        {
            return _players.FirstOrDefault(x => x.Name == name);
        }
    }
}
