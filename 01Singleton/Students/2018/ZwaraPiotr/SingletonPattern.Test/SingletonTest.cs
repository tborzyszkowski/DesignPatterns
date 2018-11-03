using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

using SingletonPattern.ZadA;
using SingletonPattern.ZadB;
using SingletonPattern.ZadC;

namespace SingletonPattern.Test
{
    [TestFixture]
    public class SingletonTest
    {
        [Test]
        /// <summary>Zad A</summary>
        public void IsSameInstance()
        {
            SingletonLazy instance1 = SingletonLazy.Instance;
            SingletonLazy instance2 = SingletonLazy.Instance;

            Assert.AreSame(instance1, instance2);
        }

        [Test]
        /// <summary>Zad B</summary>
        public void InheritedGenericSingeton()
        {
            SingletonSubClassOne subClassInstanceOne1 = SingletonSubClassOne.Instance;
            SingletonSubClassOne subClassInstanceOne2 = SingletonSubClassOne.Instance;

            SingletonSubClassTwo subClassInstanceTwo1 = SingletonSubClassTwo.Instance;
            SingletonSubClassTwo subClassInstanceTwo2 = SingletonSubClassTwo.Instance;

            Assert.AreSame(subClassInstanceOne1, subClassInstanceOne2);
            Assert.AreSame(subClassInstanceTwo1, subClassInstanceTwo2);
            Assert.AreNotSame(subClassInstanceOne1, subClassInstanceTwo1);
        }

        [Test]
        /// <summary>Zad C</summary>
        public void DeserializedIsSameInstance()
        {
            SerializableSingleton serializedSingleton = SerializableSingleton.Instance;
            SerializableSingleton deserializedSingleton;

            using (var fileStream = new FileStream("SerializableSingleton.dat", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, serializedSingleton);

                fileStream.Position = 0;
                deserializedSingleton = (SerializableSingleton)formatter.Deserialize(fileStream);
            };

            Assert.AreSame(serializedSingleton, deserializedSingleton);
        }

        [Test]
        /// <summary>Zad C</summary>
        public void SerializableSingletonStoreState()
        {
            SerializableSingleton serializedSingleton = SerializableSingleton.Instance;
            SerializableSingleton deserializedSingleton;

            serializedSingleton.TestData = "Before serialization";

            using (var fileStream = new FileStream("SerializableSingleton.dat", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, serializedSingleton);

                serializedSingleton.TestData = "After serialization";

                fileStream.Position = 0;
                deserializedSingleton = (SerializableSingleton)formatter.Deserialize(fileStream);
            };

            Assert.AreEqual(deserializedSingleton.TestData, "Before serialization");
        }
    }
}
