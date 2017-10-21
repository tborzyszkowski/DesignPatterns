using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WzoreceProjektoweSingleton.SingletonBase;
using WzoreceProjektoweSingleton.Interfaces;

namespace WzoreceProjektoweSingleton.Test
{
    /// <summary>
    /// The singleton tests class.
    /// </summary>
    public class SingletonTests
    {
        #region Methods

        #endregion

        /// <summary>
        /// The singleton performance test method.
        /// </summary>
        /// <typeparam name="TSingletonType">
        /// The generic singleton type.
        /// </typeparam>
        /// <param name="singletonInstance">
        /// The generic singleton instance.
        /// </param>
        public void SingletonPerformanceTest<TSingletonType>(TSingletonType singletonInstance) where TSingletonType : IMessageInformer, IInstance<TSingletonType>
        {
            var stopWatch = new Stopwatch();
            const int NumbeOfRetry = 30000000;

            stopWatch.Start();

            for (var i = 1; i < NumbeOfRetry; i++)
            {
                var singletonObject = singletonInstance.GetInstance;
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine($"Time needed to create {NumbeOfRetry} Instance call: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}:{ts.Milliseconds:00}");
        }

        /// <summary>
        /// The serializable singleton test method.
        /// </summary>
        /// <param name="testCaseWithLock">
        /// The test option, defines that test should be run with base singleton instane or with singletonWithLock singleton implementation.
        /// </param>
        public void SerializableTest(bool testCaseWithLock = false)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            const int NumbeOfRetry = 5000;


            for (var i = 1; i < NumbeOfRetry; i++)
            {
                if (SerializeSingletonEquals(testCaseWithLock) == false)
                {
                    throw new Exception("Object are not equal");
                }
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            Console.WriteLine($"Time needed to create {NumbeOfRetry} Instance call: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}:{ts.Milliseconds:00}");
        }

        /// <summary>
        /// The Serialize Singleton Equals method verify that serialized and deseralized singleton are the same object.
        /// </summary>
        /// <param name="testCaseWithLock"></param>
        /// <returns></returns>
        public bool SerializeSingletonEquals(bool testCaseWithLock = false)
        {
            FileStream fsLock;
            FileStream fs;

            try
            {
                var formatter = new BinaryFormatter();

                Singleton[] singletonsCopy = { Singleton.Instance, Singleton.Instance };
                SingletonWithLock[] singletonWithLocksCopy = { SingletonWithLock.Instance, SingletonWithLock.Instance };

                if (testCaseWithLock)
                {
                    using (fsLock = new FileStream("DataFileLock.dat", FileMode.Create))
                    {
                        formatter.Serialize(fsLock, singletonWithLocksCopy);
                        fsLock.Position = 0;
                        var singletonWithLocksCopyAfterDeserialize = (SingletonWithLock[])formatter.Deserialize(fsLock);

                        var checkElementsDeseralized = (singletonWithLocksCopyAfterDeserialize[0] == singletonWithLocksCopyAfterDeserialize[1]);
                        var checkElementsDeseralizedAndBefore = (singletonWithLocksCopy[0] == singletonWithLocksCopyAfterDeserialize[0]);
                        return checkElementsDeseralized && checkElementsDeseralizedAndBefore;
                    }
                }
                using (fs = new FileStream("DataFile.dat", FileMode.Create))
                {
                    formatter.Serialize(fs, singletonsCopy);
                    fs.Position = 0;
                    var singletonsCopyAfterDeserialize = (Singleton[])formatter.Deserialize(fs);

                    var checkElementsDeseralized = (singletonsCopyAfterDeserialize[0] == singletonsCopyAfterDeserialize[1]);
                    var checkElementsDeseralizedAndBefore = (singletonsCopy[0] == singletonsCopyAfterDeserialize[0]);
                    return checkElementsDeseralized && checkElementsDeseralizedAndBefore;
                }
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
        }
    }
}
