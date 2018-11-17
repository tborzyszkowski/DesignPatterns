using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Singleton
{
    [Serializable]
    public class ShoppingList : ISerializable
    {
        private static ShoppingList _shoppingListInstance;
        private readonly List<Product> _productList;
        private static readonly object MyLock = new object();
        public static ShoppingList ShoppingListInstance
        {
            get
            {
                if (_shoppingListInstance == null)
                {
                    lock (MyLock)
                    {
                        if (_shoppingListInstance == null)
                        {
                            _shoppingListInstance = new ShoppingList();
                        }

                    }
                }
                return _shoppingListInstance;
            }
        }
        private ShoppingList()
        {
            _productList = new List<Product>();
        }
        protected ShoppingList(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            _shoppingListInstance = (ShoppingList)info.GetValue("Instance", typeof(ShoppingList));
            _productList = (List<Product>)info.GetValue("ProductList", typeof(List<Product>));
        }
        public List<Product> GetProductList()
        {
            lock (MyLock)
            {
                return _productList;
            }
        }
        public void AddProduct(Product product)
        {
            lock (MyLock)
            {
                _productList.Add(product);
            }
        }
        public void DeletaAllProducts()
        {
            lock (MyLock)
            {
                _productList.Clear();
            }
        }
        public void DeleteInstance()
        {
            _shoppingListInstance = null;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("Instance", ShoppingListInstance);
            info.AddValue("ProductList", _productList);
        }
    }
}
