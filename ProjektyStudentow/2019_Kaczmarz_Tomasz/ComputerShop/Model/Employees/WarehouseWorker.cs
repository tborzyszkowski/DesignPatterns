using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model.Employees
{
    class WarehouseWorker : Employee
    {
        public override string ProcessOrder(Order order)
        {
            if (order.Type == OrderType.Warranty)
                return "Złożenie gwarancji potwierdzone w magazynie.";
            else
                return successor.ProcessOrder(order);
        }
    }
}
