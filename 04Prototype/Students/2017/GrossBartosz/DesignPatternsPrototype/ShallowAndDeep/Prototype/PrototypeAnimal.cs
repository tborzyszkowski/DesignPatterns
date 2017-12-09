using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DesignPatternsPrototype.BaseShallowAndDeep.ConcretePrototype;
using DesignPatternsPrototype.DeeperData;

namespace DesignPatternsPrototype.BaseShallowAndDeep.Prototype
{
    [Serializable()]
    public abstract class PrototypeAnimal<T>
    {

        public string Name { get; set; }

        public string Barcode { get; set; }

        AdditionalDetails details = new AdditionalDetails();

        public AdditionalDetails Details
        {
            get { return details; }
            set { details = value; }
        }

        // Shallow copy
        public virtual T Clone()
        {
            return (T)this.MemberwiseClone();
        }

        // Deep Copy
        public T DeepCopy()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            T copy = (T)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }
}
