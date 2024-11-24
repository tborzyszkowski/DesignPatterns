﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Chatroom {
    class Participant {
        private Chatroom _chatroom;
        private string _name;

        // Constructor
        public Participant(string name) {
            this._name = name;
        }

        // Gets participant name
        public string Name
        {
            get { return _name; }
        }

        // Gets chatroom
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        // Sends message to given participant
        public void Send(string to, string message) {
            _chatroom.Send(_name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(
          string from, string message) {
            Console.WriteLine($"{from} to {Name}: '{message}'");
        }
    }
}
