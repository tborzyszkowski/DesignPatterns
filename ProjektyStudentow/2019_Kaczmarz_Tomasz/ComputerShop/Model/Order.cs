using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model
{
    class Order
    {
        public OrderType Type { get; private set; }
        public ComputerType ComputerType { get; private set; } = ComputerType.Unknown;
        public int Budget { get; private set; } = 0;

        public Order(OrderType type)
        {
            Type = type;
        }

        public Order(OrderType type, ComputerType computerType)
        {
            Type = type;
            ComputerType = computerType;
        }

        public Order(OrderType type, int budget)
        {
            Type = type;
            Budget = budget;
        }
    }
}
