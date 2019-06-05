using Player.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Player.Services
{
    class ConnectionService
    {
        private Me _player = new Me();
        private ConnectionStrategy _connectionStrategy;

        public void SetConnectionStrategy(ConnectionStrategy connectionStrategy)
        {
            _connectionStrategy = connectionStrategy;
        }

        public void Create(string name)
        {
            _player.Name = name;
        }

        public void Run()
        {
            _connectionStrategy.Run(_player);
        }
        public Me GetMe()
        {
            return _player;
        }
    }
}
