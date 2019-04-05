using BuilderPattern.AbstractFactory;
using BuilderPattern.AbstractFactory.ComputerFactory;
using BuilderPattern.FluentBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BuilderPattern.FluentBuilder2;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchBuilder>();

            Console.ReadKey();

        }
    }
}
