using Factory.AbstractFactory;
using Factory.FactoryMethod;
using Factory.FactoryReflection;
using Factory.FactorySuplier;
using Factory.Products;
using Factory.Products.Rices;
using Factory.SimpleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10_000_000;
            //initialization
            var simpleFactory = new SimpleFactory.CarbohydrateStore();
            var factoryMethod = RiceStore.Instance;
            var abstractFactory = new Store(HalinaFactory.Instance);
            var reflectionFactory = ReflectionRiceFactory.Instance;
            reflectionFactory.RegisterRices();
            var noRefectionFactory = NonReflectionRiceFactory.Instance;
            noRefectionFactory.RegisterRice("basmati", typeof(Basmati));
            //testing
            SimpleFactoryCreate(n, simpleFactory);
            FactoryMethodCreate(n, factoryMethod);
            AbstractFactoryCreate(n, abstractFactory);
            ReflectionFactoryCreate(n, reflectionFactory);
            NoReflectionFactoryCreate(n, noRefectionFactory);
        }
        private static void SimpleFactoryCreate(int n,SimpleFactory.CarbohydrateStore simpleFactory)
        {
            Carbohydrate carbohydrate;
            for(int i = 0; i < n; i++)
            {
                carbohydrate = simpleFactory.OrderRice("basmati");
            }
        }
        private static void FactoryMethodCreate(int n, RiceStore factoryMethod)
        {
            Carbohydrate carbohydrate;
            for (int i = 0; i < n; i++)
            {
                carbohydrate = factoryMethod.Build("basmati");
            }
        }
        private static void AbstractFactoryCreate(int n, Store abstractFactory)
        {
            Carbohydrate carbohydrate;
            for (int i = 0; i < n; i++)
            {
                carbohydrate = abstractFactory.BuildRice();
            }
        }
        private static void ReflectionFactoryCreate(int n, ReflectionRiceFactory reflectionFactory)
        {
            Carbohydrate carbohydrate;
            for (int i = 0; i < n; i++)
            {
                carbohydrate = reflectionFactory.GetRice("basmati");
            }
        }
        private static void NoReflectionFactoryCreate(int n, NonReflectionRiceFactory noReflectionFactory)
        {
            Carbohydrate carbohydrate;
            for (int i = 0; i < n; i++)
            {
                carbohydrate = noReflectionFactory.GetRice("basmati");
            }
        }
    }
}
