using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializableSingleton
{
    [Serializable]
    public sealed class Singleton : ISerializable
    {
        private static Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance { get { return lazy.Value; } set { lazy = new Lazy<Singleton>(() => value); } }
        public string Name { get; set; }

        private Singleton()
        {
            Name = "Robert";
        }

        // Implement this method to serialize data. The method is called 
        // on serialization.
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("name", Instance.Name);
        }
        private Singleton(SerializationInfo info, StreamingContext context) {
            Name = info.GetValue("name", typeof(string)) as string;
            if (!lazy.IsValueCreated)
                Instance = this;

            Instance.Name = Name;
        }

        public static void Cleanup()
        {
            if (lazy.IsValueCreated)
                Instance = new Singleton();
        }
    }

}
