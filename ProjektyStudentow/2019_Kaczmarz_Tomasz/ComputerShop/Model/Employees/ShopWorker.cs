using ComputerShop.Adapter;

namespace ComputerShop.Model.Employees
{
    class ShopWorker : Employee
    {
        public override string ProcessOrder(Order order)
        {
            if (order.Type == OrderType.BuyComputer)
            {
                return ComputerFactory.Instance.CreateComputer(order.ComputerType).ShowSpecs();
            }
            else
                return successor.ProcessOrder(order);
        }
    }
}
