using System;
using System.Collections.Generic;
using System.Diagnostics;

using PrototypePattern.Abstraction;
using PrototypePattern.Implementation;

namespace PrototypePattern
{
    internal class Program
    {
        private static PrototypeUsingSerialization prototypeUsingSerialization;
        private static PrototypeUsingReflection prototypeUsingReflection;

        private static void SetUp()
        {
            prototypeUsingSerialization = new PrototypeUsingSerialization
            {
                Number = 99,
                Text = "Test String",
                ReferenceObject = new ReferenceObject { Text = "Some Text" },
                Collection = new List<ReferenceObject>
                {
                    new ReferenceObject { Text = "1" },
                    new ReferenceObject { Text = "2" }
                }
            };

            prototypeUsingReflection = new PrototypeUsingReflection
            {
                Number = 99,
                Text = "Test String",
                ReferenceObject = new ReferenceObject { Text = "Some Text" },
                Collection = new List<ReferenceObject>
                {
                    new ReferenceObject { Text = "1" },
                    new ReferenceObject { Text = "2" }
                }
            };
        }

        private static void Main(string[] args)
        {
            SetUp();

            var stopwatch = new Stopwatch();

            // ====== PrototypeUsingSerialization ======

            stopwatch.Start();

            PrototypeUsingSerialization prototypeUsingSerializationClone = null;
            for (int i = 0; i < 10_000; i++)
                prototypeUsingSerializationClone = prototypeUsingSerialization.DeepClone();

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for {nameof(PrototypeUsingSerialization)}: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            // ====== PrototypeUsingReflection =========

            stopwatch.Start();

            PrototypeUsingReflection prototypeUsingReflectionClone = null;
            for (int i = 0; i < 10_000; i++)
                prototypeUsingReflectionClone = prototypeUsingReflection.DeepClone();

            stopwatch.Stop();
            Console.WriteLine($"Number of ticks for {nameof(PrototypeUsingReflection)}: {stopwatch.ElapsedTicks}");

            stopwatch.Reset();

            Console.ReadKey();
        }
    }
}
