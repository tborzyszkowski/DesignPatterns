using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton;
using Singleton.zadA;

namespace Test
{
    [TestClass]
    public class Tests
    {
        Random rand = new Random();

        [TestMethod]
        public void ZadanieALazySingletonOneTask()
        {
            LazySingleton s = LazySingleton.singleton;
            Assert.AreEqual(LazySingleton.constructorCount, 1, "Ilość Singletonów różna od 1!");
        }


        [TestMethod]
        public void ZadanieASingletonWithLockOneTask()
        {
            SingletonWithLock s = SingletonWithLock.GetSingleton();
            Assert.AreEqual(SingletonWithLock.constructorCount, 1, "Ilość Singletonów różna od 1!");
        }


        [TestMethod]
        public void ZadanieALazySingletonManyTasks()
        {
            Task[] tasks = new Task[100];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    LazySingleton s = LazySingleton.singleton;
                });
                tasks[i].Start();
            }

            tasks.AsParallel().ForAll(task => task.Wait());
            Assert.AreEqual(LazySingleton.constructorCount, 1, "Ilość Singletonów różna od 1!");
        }


        [TestMethod]
        public void ZadanieASingletonWithLockManyTasks()
        {
            Task[] tasks = new Task[100];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    SingletonWithLock s = SingletonWithLock.GetSingleton();
                });
                tasks[i].Start();
            }

            tasks.AsParallel().ForAll(task => task.Wait());
            Assert.AreEqual(SingletonWithLock.constructorCount, 1, "Ilość Singletonów różna od 1!");
        }


        [TestMethod]
        public void ZadanieB()
        {
            SingletonFactory factory = SingletonFactory.CreateSingletonFactory();
            int singletonCount = 1000000;
            Type[] typeArray = { typeof(BasicSingleton), typeof(ExtendedSingletonA), typeof(ExtendedSingletonB) };
            ISet<BasicSingleton> set = new HashSet<BasicSingleton>();

            for (int i = 0; i < singletonCount; i++)
            {
                BasicSingleton singleton = factory.CreateSingleton(typeArray[rand.Next(typeArray.Length)]);
                set.Add(singleton);
            }

            Assert.AreEqual(set.Count, 3, "Ilość singletonów różna od 3!");
        }
    }
}
