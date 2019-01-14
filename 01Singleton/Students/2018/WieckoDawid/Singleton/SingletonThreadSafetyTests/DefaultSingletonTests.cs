using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singleton.DefaultSingleton;
using Singleton.DoubleCheckedLockingSingleton;
using Singleton.SingleCheckedSingleton;
using System.Threading.Tasks;

namespace SingletonThreadSafetyTests
{
    /// <summary>
    ///     This test class will check that Singleton contains
    ///     only one instance for running with multiple threads for
    ///     single lock and double lock.
    ///     Compare performance of a single, double and without lock mechanism.
    /// </summary>
    [TestClass]
    public class DefaultSingletonTests
    {
        #region Fields

        int invokeCounter = 100_000_000;
        int numberOfThreads = 100_000;

        #endregion

        #region Tests

        [TestMethod]
        [TestCategory("Equality")]
        public void CheckIf_SingletonInstances_AreEqual()
        {
            SingleCheckSingleton singleton = SingleCheckSingleton.GetSingletonInstance();
            SingleCheckSingleton secondSingleton = SingleCheckSingleton.GetSingletonInstance();

            Assert.AreSame(singleton, secondSingleton);
        }

        [TestMethod]
        [TestCategory("Equality")]
        public void CheckIf_DoubleCheckSingletonInstances_AreEqual()
        {
            DoubleCheckLockingSingleton singleton = DoubleCheckLockingSingleton.GetSingletonInstance();
            DoubleCheckLockingSingleton secondSingleton = DoubleCheckLockingSingleton.GetSingletonInstance();

            Assert.AreEqual(singleton, secondSingleton);
        }

        [TestMethod]
        [TestCategory("Equality")]
        public void CheckIf_DoubleCheckSingleton_Contains_OneInstance()
        {
            for (int i = 0; i < invokeCounter; i++)
            {
                DoubleCheckLockingSingleton.GetSingletonInstance();
            }

            Assert.AreEqual(1, DoubleCheckLockingSingleton.SingletonInstances);
        }

        [TestMethod]
        [TestCategory("Equality - thread")]
        public void CheckIf_DoubleCheckSingleton_Contains_OneInstance_Parallel()
        {
            Parallel.For(0, numberOfThreads, task =>
            {
                DoubleCheckLockingSingleton.GetSingletonInstance();
            });
            Assert.AreEqual(1, DoubleCheckLockingSingleton.SingletonInstances);
        }

        [TestMethod]
        [TestCategory("Equality - thread")]
        public void CheckIf_DefaultSingleton_DoesNot_Contain_OneInstance_Parallel()
        {
            Parallel.For(0, numberOfThreads, task =>
            {
                DefaultSingleton.GetSingletonInstance();
            });
            Assert.AreNotEqual(1, DefaultSingleton.singletonCounter);
        }

        [TestMethod]
        [TestCategory("Equality - thread")]
        public void CheckIf_SingleCkeckSingleton_Contains_OneInstance_Parallel()
        {
            Parallel.For(0, numberOfThreads, task =>
            {
                SingleCheckSingleton.GetSingletonInstance();
            });
            Assert.AreEqual(1, SingleCheckSingleton.singletonCounter);
        }

        [TestMethod]
        [TestCategory("Performance - initialization")]
        public void TestPerformance_Of_DoubleLock_And_SingleLock()
        {
            DoubleCheckLockingSingleton doubleCheckSingleton = null;
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            stopWatch.Start();
            for (int i = 0; i < invokeCounter; i++)
            {
                doubleCheckSingleton = DoubleCheckLockingSingleton.GetSingletonInstance();
            }
            stopWatch.Stop();
            var elapsedDoubleCheck = stopWatch.ElapsedMilliseconds;

            SingleCheckSingleton singleCheckSingleton = null;

            stopWatch.Start();
            for (int i = 0; i < invokeCounter; i++)
            {
                singleCheckSingleton = SingleCheckSingleton.GetSingletonInstance();
            }
            stopWatch.Stop();
            var elapsedSingleCheck = stopWatch.ElapsedMilliseconds;

            Assert.IsTrue(elapsedDoubleCheck < elapsedSingleCheck);
        }

        [TestMethod]
        [TestCategory("Performance - thread")]
        public void TestThredsPerformance_Of_DoubleLock_And_SingleLock()
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            stopWatch.Start();
            Parallel.For(0, numberOfThreads, task =>
            {
                DoubleCheckLockingSingleton.GetSingletonInstance();
            });
            stopWatch.Stop();
            var elapsedDoubleCheck = stopWatch.ElapsedTicks;

            stopWatch.Start();
            Parallel.For(0, numberOfThreads, task =>
            {
                SingleCheckSingleton.GetSingletonInstance();
            });
            stopWatch.Stop();
            var elapsedSingleCheck = stopWatch.ElapsedTicks;

            Assert.IsTrue(elapsedDoubleCheck < elapsedSingleCheck, string.Format("Elapsed single: {0}, double: {1}", 
                                                                                elapsedSingleCheck, elapsedDoubleCheck));
        }

        [TestMethod]
        [TestCategory("Performance - thread")]
        public void TestThredsPerformance_Of_SingleLock_And_Default()
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            stopWatch.Start();
            Parallel.For(0, numberOfThreads, task =>
            {
                SingleCheckSingleton.GetSingletonInstance();
            });
            stopWatch.Stop();
            var elapsedSingleCheck = stopWatch.ElapsedTicks;

            stopWatch.Start();
            Parallel.For(0, numberOfThreads, task =>
            {
                DefaultSingleton.GetSingletonInstance();
            });
            stopWatch.Stop();
            var elapsedDefaultCheck = stopWatch.ElapsedTicks;

            Assert.IsTrue(elapsedDefaultCheck > elapsedSingleCheck, string.Format("Elapsed single: {0}, default: {1}",
                                                                                elapsedSingleCheck, elapsedDefaultCheck));
        }

        #endregion
    }
}
