using System;

using BuilderPattern.Implementation;

using AutofacContainer = Autofac.Core.Container;
using SimpleInjectorContainer = SimpleInjector.Container;

namespace BuilderPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var director = new Director();

            AutofacContainer autofacContainer = director.Construct(new AutofacContainerBuilder());
            SimpleInjectorContainer container = director.Construct(new SimpleInjectorContainerBuilder());

            Console.ReadKey();
        }
    }
}
