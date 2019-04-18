using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ThreadSafety.Tests
{
    public class ThreadSafety
    {
        [Test]
        public void SingleThread()
        {
            var instance1 = LazySingleton.Instance;
            var instance2 = LazySingleton.Instance;

            Assert.Multiple(() =>
            {
                Assert.AreSame(instance1, instance2);
                Assert.AreEqual(instance1.GetHashCode(), instance2.GetHashCode());
                Assert.AreEqual(1, LazySingleton.Counter, "There is more than 1 instance!");
            });
        }

        [Test]
        public void MultiThread()
        {
            LazySingleton instance1 = null;
            LazySingleton instance2 = null;

            Parallel.Invoke(
                () => { instance1 = LazySingleton.Instance; },
                () => { instance2 = LazySingleton.Instance; }
            );

            Assert.Multiple(() =>
            {
                Assert.AreSame(instance1, instance2);
                Assert.AreEqual(instance1.GetHashCode(), instance2.GetHashCode());
                Assert.AreEqual(1, LazySingleton.Counter, "There is more than 1 instance!");

            });
        }

        [Test]
        public void MultiThread_2_CountInstances()
        {
            var tasks = new Task[5];
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    var instance = LazySingleton.Instance;
                });
                tasks[i].Start();
            }

            tasks.AsParallel().ForAll(task => task.Wait());
            Assert.AreEqual(1, LazySingleton.Counter, "There is more than 1 instance!");
        }
    }
}