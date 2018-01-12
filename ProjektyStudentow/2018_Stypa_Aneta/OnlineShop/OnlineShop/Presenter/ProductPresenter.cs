using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Presenter
{
    public class ProductPresenter
    {
        public ProductDocument document = new ProductDocument();
        
        public void OnInit()
        {
            document.ProductList = new List<Product>();
            document.ProductList = ProductSingleton.Instance.GetProduct();
            //document.ProductList.Add(new Product() { ID = 1, Name = "Czekolada", Price = 2.32M, ProductType = Model.Type.Slodycze });
            //document.ProductList.Add(new Product() { ID = 2, Name = "Kurczak", Price = 15.99M, ProductType = Model.Type.Mieso });
            //document.ProductList.Add(new Product() { ID = 3, Name = "Winogrona", Price = 7.59M, ProductType = Model.Type.Owoce });
            //document.ProductList.Add(new Product() { ID = 4, Name = "Cebula", Price = 0.99M, ProductType = Model.Type.Warzywa });
            //document.ProductList.Add(new Product() { ID = 5, Name = "Woda", Price = 1.58M, ProductType = Model.Type.Napoje });
        }

        public List<Product> AddNewProduct(Product product)
        {
            ProductSingleton.Instance.AddProduct(product);
           
            return ProductSingleton.Instance.GetProduct();
        }

        public List<Product> Calulate(string c)
        {
            var tmp = new List<Product>();
            tmp = ProductSingleton.Instance.GetProduct();

            ContextStrategy context = null;
            switch (c) {
                case "Zloty":
                  context = new ContextStrategy(new Zloty());
                  break;
                case "Dolar":
                    context = new ContextStrategy(new Dolar());
                    break;
                case "Euro":
                    context = new ContextStrategy(new Euro());
                    break;
                case "Funt":
                    context = new ContextStrategy(new Funt());
                    break;
                default:
                   break;
            }
            return context.Calculate(tmp);
        }

        public void WriteToCSV()
        {
            CSVAdaptee csv = new CSVAdaptee();
            csv.ToCSV(document.ProductList);
        }

        public void WriteToTxt()
        {
            TxtAdaptee txt = new TxtAdaptee();
            txt.ToTxt(document.ProductList);
        }

    }

    public class ProductDocument
    {
        public List<Product> ProductList { get; set; }
    }
}
