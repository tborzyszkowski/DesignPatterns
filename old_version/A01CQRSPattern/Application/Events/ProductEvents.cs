using Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Events
{

    public class ProductCreated : INotification
    {
        public Product NewProduct { get; }

        public ProductCreated(Product newProduct)
        {
            NewProduct = newProduct;
        }
    }

    public class ProductDeleted : INotification
    {
        public Product DeletedProduct { get; }

        public ProductDeleted(Product deletedProduct)
        {
            DeletedProduct = deletedProduct;
        }
    }


    public class ProductCurrentStockUpdated : INotification
    {
        public Product NewProduct { get; }

        public int OldStock { get; }
        

        public ProductCurrentStockUpdated(Product newProduct, int oldStock)
        {
            NewProduct = newProduct;
            OldStock = oldStock;
        }
    }

    public class ProductUnitPriceUpdated : INotification
    {
        public Product NewProduct { get; }

        public decimal OldUnitPrice { get; }


        public ProductUnitPriceUpdated(Product newProduct, decimal oldUnitPrice)
        {
            NewProduct = newProduct;
            OldUnitPrice = oldUnitPrice;
        }
    }

}
