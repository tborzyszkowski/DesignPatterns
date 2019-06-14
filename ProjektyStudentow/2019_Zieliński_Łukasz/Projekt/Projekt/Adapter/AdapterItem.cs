using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Factory.Products;
using Projekt.Observer;

namespace Projekt.Adapter
{
    public class AdapterItem : Product
    {
        Product item;
        CommandsObserver observerable;
        public AdapterItem(Product item)
        {
            this.item = item;
            this.observerable = new CommandsObserver(observerable);
            item.Decoration();
        }



    }
}
