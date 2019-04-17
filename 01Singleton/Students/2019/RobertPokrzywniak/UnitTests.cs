using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializableSingleton;

namespace SingletonTests
{
    [TestClass]
    public class UnitTests
    {
        [TestCleanup]
        public void Cleanup()
        {
            Singleton.Cleanup();
        }
        [TestMethod]
        public void TestSameInstance()
        {
            var instanceOne = Singleton.Instance;
            var instanceTwo = Singleton.Instance;

            Assert.IsTrue(instanceOne.Name == "Robert" && instanceTwo.Name == "Robert");
            Assert.AreSame(instanceOne,instanceTwo);
        }
        [TestMethod]
        public async Task TestSameInstanceAsync()
        {
            Singleton instanceOne = null;
            Singleton instanceTwo = null;

            var tasks = new List<Task>
            {
                Task.Run(() => instanceOne = Singleton.Instance),
                Task.Run(() => instanceTwo = Singleton.Instance)
            };

            await Task.WhenAll(tasks);

            Assert.IsTrue(instanceOne.Name == "Robert" && instanceTwo.Name == "Robert");
            Assert.AreSame(instanceOne, instanceTwo);
        }
        [TestMethod]
        public void TestSerialization()
        {
            Singleton instanceOne = null;
            Singleton instanceTwo = null;
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                instanceOne = Singleton.Instance;
                instanceOne.Name = "Before Serialization";
                formatter.Serialize(fs, instanceOne);
                instanceOne.Name = "After Serialization";
                fs.Position = 0;
                instanceTwo = Deserialize(formatter.Deserialize(fs));

            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
                Assert.IsTrue(instanceOne.Name == "Before Serialization" && instanceTwo.Name == "Before Serialization");
                Assert.AreSame(instanceOne, instanceTwo);
            }
        }
        private Singleton Deserialize(object deserialized)
        {
            return Singleton.Instance;
        }
    }
}
