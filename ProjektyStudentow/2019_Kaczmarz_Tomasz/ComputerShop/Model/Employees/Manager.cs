using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model.Employees
{
    class Manager : Employee
    {
        public override string ProcessOrder(Order order)
        {
            if (order.Type == OrderType.Complaint)
                return "Skarga dostarczona do menedżera.";
            else
                return "Nieznany rodzaj zamówienia.";
        }
    }
}
