using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Factory.Products;
using Projekt.Factory;

namespace Projekt.Factory
{
    public interface InterfaceFactory
    {
        Product CreateChair();
        Product CreateBTable();
        Product CreateSTable();
        Product CreateStool();
    }
}
