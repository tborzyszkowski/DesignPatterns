using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt;
using Projekt.Factory.Products;
using Projekt.Factory;

namespace Projekt.Factory
{
    public abstract class AFactory
    {
        private readonly InterfaceFactory Make;

        protected AFactory(InterfaceFactory ProductFactory)
        {
            this.Make = ProductFactory;
        }
        public Product CreateChair()
        {
            return Make.CreateChair();
        }
        public Product CreateBTable()
        {
            return Make.CreateBTable();
        }
        public Product CreateSTable()
        {
            return Make.CreateSTable();
        }
        public Product CreateStool()
        {
            return Make.CreateStool();
        }
    }
}
