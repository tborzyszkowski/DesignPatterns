using ComputerShop.Model;
using ComputerShop.Model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop
{
    /// <summary>
    /// Fasada (Facade) - strukturalny
    /// </summary>
    class Shop
    {
        private Manager manager;
        private WarehouseWorker warehouseWorker;
        private ShopWorker shopWorker;

        public Shop()
        {
            manager = new Manager();
            warehouseWorker = new WarehouseWorker();
            shopWorker = new ShopWorker();
            shopWorker.SetSuccessor(warehouseWorker);
            warehouseWorker.SetSuccessor(manager);
        }

        public string TakeOrder(Order order)
        {
            return shopWorker.ProcessOrder(order);
        }
    }
}
