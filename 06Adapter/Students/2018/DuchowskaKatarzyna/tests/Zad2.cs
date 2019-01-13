using Adapter.zad2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class Zad2
    {
        [Test]
        public void SendingMessageViaTelephone()
        {
            ConnectionAdapter adapter = new ConnectionAdapter(new Telephone());
            bool success = adapter.SendMessage("Message1");

            Assert.IsTrue(success);
        }

        [Test]
        public void SendingMessageViaPidgeon()
        {
            ConnectionAdapter adapter = new ConnectionAdapter(new Pidgeon());
            bool success = adapter.SendMessage("Message2");

            Assert.IsTrue(success);
        }

        [Test]
        public void SendingMessageViaEmail()
        {
            ConnectionAdapter adapter = new ConnectionAdapter(new Email());
            bool success = adapter.SendMessage("Message3");

            Assert.IsTrue(success);
        }
    }
}
