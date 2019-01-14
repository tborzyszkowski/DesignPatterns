using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;

namespace SingletonTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompareInstancesSingleton()
        {
            Singleton.Singleton instance1 = Singleton.Singleton.GetInstance();
            Singleton.Singleton instance2 = Singleton.Singleton.GetInstance();

            Assert.AreSame(instance1, instance2);
            
        }
        [TestMethod]
        public void CompareTime()
        {
            Stopwatch stopwatch = new Stopwatch();
            long time = 0;
            long time2 = 0;

            stopwatch.Start();
            CreateInstancesSingletonLock();
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();
            CreateInstancesSingletonLock2();
            stopwatch.Stop();
            time2 = stopwatch.ElapsedMilliseconds;


            Assert.IsTrue(time > time2);
        }

        public void CreateInstancesSingletonLock()
        {
            Parallel.For(0, 1_000_000, instance =>
            {
                SingletonLock.GetInstance();
            });
        }
        public void CreateInstancesSingletonLock2()
        {
            Parallel.For(0, 1_000_000, instance =>
            {
                SingletonLock2.GetInstance();
            });
        }
    }
}
