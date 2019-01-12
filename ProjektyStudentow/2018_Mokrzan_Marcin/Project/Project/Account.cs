using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Account : Player
    {
        public string id;
        public string name;

        private static Account instance = null;
        private static readonly object padlock = new object();

        public static string GenerateRandomUserId()
        {
            Random random = new Random();
            const string characters = "0123456789";
            return new string(Enumerable.Repeat(characters, 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        Account()
        {
            this.id = GenerateRandomUserId();
            this.name = "Guest-" + this.id;
        }

        public static Account Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Account();
                    }
                    return instance;
                }
            }
        }
    }
    
}
