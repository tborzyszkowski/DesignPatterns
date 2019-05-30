using Microsoft.VisualStudio.TestTools.UnitTesting;
using Printer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterTests
{
    [TestClass]
    public class SingletonTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            var type = typeof(Creator);
            var field = type.GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, null);
        }

        [TestMethod]
        public void AreSingletonInstancesSame()
        {
            var singletonOne = Creator.Instance;
            var singletonTwo = Creator.Instance;

            Assert.AreSame(singletonOne, singletonTwo);
        }

        [TestMethod]
        public void AreSingletonHashcodeInstancesSame()
        {
            var singletonOne = Creator.Instance;
            var singletonTwo = Creator.Instance;

            Assert.AreEqual(singletonOne.GetHashCode(), singletonTwo.GetHashCode());
        }

        [TestMethod]
        public void AreSingletonInstancesSameMultipleThread()
        {
            var thread_count = 100;
            var threads = new List<Thread>();
            var instances = new List<Creator>();

            for (int i = 0; i < thread_count; i++)
            {
                var thread = new Thread(() =>
                {
                    instances.Add(Creator.Instance);
                });
                threads.Add(thread);
                thread.Start();
            }

            threads.ForEach(x => x.Join());
            instances.ForEach(x => Assert.AreSame(instances[0], x));
        }
    }
}
