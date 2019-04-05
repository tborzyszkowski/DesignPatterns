using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace SingletonTest
{
    [TestClass]
    public class SingletonTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            var type = typeof(SingletonBase);
            var field = type.GetField("instance", BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, null);
        }

        [TestMethod]
        public void AreSingletonInstancesSame()
        {
            var singletonOne = SingletonBase.GetInstance<SingletonBase>();
            var singletonTwo = SingletonBase.GetInstance<SingletonBase>(); ;

            Assert.IsInstanceOfType(singletonOne, typeof(SingletonBase));
            Assert.IsInstanceOfType(singletonTwo, typeof(SingletonBase));
            Assert.AreSame(singletonOne, singletonTwo);
        }

        [TestMethod]
        public void AreSingletonHashcodeInstancesSame()
        {
            var singletonOne = SingletonBase.GetInstance<SingletonBase>();
            var singletonTwo = SingletonBase.GetInstance<SingletonBase>();

            Assert.IsInstanceOfType(singletonOne, typeof(SingletonBase));
            Assert.IsInstanceOfType(singletonTwo, typeof(SingletonBase));
            Assert.AreEqual(singletonOne.GetHashCode(), singletonTwo.GetHashCode());
        }

        [TestMethod]
        public void AreSingletonInstancesSame_MultipleThread()
        {
            var thread_count = 100;
            var threads = new List<Thread>();
            var instances = new List<SingletonBase>();

            for (int i = 0; i < thread_count; i++)
            {
                var thread = new Thread(() =>
                {
                    instances.Add(SingletonBase.GetInstance<SingletonBase>());
                });
                threads.Add(thread);
                thread.Start();
            }

            threads.ForEach(x => x.Join());

            instances.ForEach(x => Assert.AreSame(instances[0], x));
        }

        [TestMethod]
        public void AreTwoInheritedInstancesFromSingletonAreSame()
        {
            var singletonOne = SingletonBase.GetInstance<ChildOneSingleton>();
            var singletonTwo = SingletonBase.GetInstance<ChildTwoSingleton>();

            Assert.AreEqual(singletonOne.TestMethod(), singletonTwo.TestMethod());
            Console.WriteLine(singletonOne.TestMethod());
            Assert.IsInstanceOfType(singletonOne, typeof(ChildOneSingleton));
            Assert.IsInstanceOfType(singletonTwo, typeof(ChildOneSingleton));
            Assert.AreSame(singletonOne, singletonTwo);
        }
    }
}
