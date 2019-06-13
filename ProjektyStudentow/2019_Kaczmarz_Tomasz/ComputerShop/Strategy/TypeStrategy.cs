using ComputerShop.Model;
using ComputerShop.Model.Employees;

namespace ComputerShop.Strategy
{
    class TypeStrategy : OrderStrategy
    {
        public override string HandleOrder(Order order, Employee employee)
        {
            return employee.ProcessOrder(order);
        }
    }
}
