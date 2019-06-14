using ComputerShop.Model;
using ComputerShop.Model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Strategy
{
    abstract class OrderStrategy
    {
        abstract public string HandleOrder(Order order, Employee employee);
    }
}
