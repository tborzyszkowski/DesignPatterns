using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Factory.Products;
using Projekt;


namespace Projekt.Factory
{
    public class LocalFactory : InterfaceFactory
    {
        private static readonly Lazy<LocalFactory> MethodInstance =
            new Lazy<LocalFactory>(() => Activator.CreateInstance(typeof(LocalFactory), nonPublic: true) as LocalFactory);
        public static LocalFactory Instance
        {
            get { return MethodInstance.Value; }
        }
        public Product CreateChair()
        {
            return new Chair();
        }
        public Product CreateBTable()
        {
            return new BigTable();
        }
        public Product CreateSTable()
        {
            return new SmallTable();
        }
        public Product CreateStool()
        {
            return new Stool();
        }
    }
}
