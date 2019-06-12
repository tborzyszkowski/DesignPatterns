using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Model;
using ComputerShop.Model.Employees;

namespace ComputerShop.Strategy
{
    class BudgetStrategy : OrderStrategy
    {
        public override string HandleOrder(Order order, Employee employee)
        {
            if (order.Budget < 2000)
                return employee.ProcessOrder(new Order(order.Type, ComputerType.Office));
            else if (order.Budget >= 2000 && order.Budget < 4500)
                return employee.ProcessOrder(new Order(order.Type, ComputerType.Home));
            else
                return employee.ProcessOrder(new Order(order.Type, ComputerType.Gaming));
        }
    }
}
