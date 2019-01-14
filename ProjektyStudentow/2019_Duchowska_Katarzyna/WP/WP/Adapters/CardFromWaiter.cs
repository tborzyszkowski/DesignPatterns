using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Adapters
{
    public class CardFromWaiter
    {
        public Dictionary<String, String> Card { get; set; } = new Dictionary<String, String>();

        public CardFromWaiter(List<String> list)
        {
            Card.Add("Alcohol", list[0]);
            Card.Add("Soft", list[1]);
        }
    }
}
