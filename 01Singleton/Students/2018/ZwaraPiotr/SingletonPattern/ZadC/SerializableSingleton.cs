using System;
using System.Runtime.Serialization;
using AutoMapper;
using AutoMapper.Configuration;

namespace SingletonPattern.ZadC
{
    [Serializable]
    public class SerializableSingleton : ISerializable, ISingletonState
    {
        private static readonly Lazy<SerializableSingleton> lazyIstance = new Lazy<SerializableSingleton>(() => new SerializableSingleton());

        private SerializableSingleton() { }

        public string TestData { get; set; } = "Initial";

        public static SerializableSingleton Instance
        {
            get { return lazyIstance.Value; }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            SingletonWrapper.State = lazyIstance.Value;
            info.SetType(typeof(SingletonWrapper));
        }
    }

    [Serializable]
    internal class SingletonWrapper : IObjectReference
    {
        private static IMapper mapper =
            new MapperConfiguration(new MapperConfigurationExpression()).CreateMapper();

        private static SingletonState state = null;

        public static ISingletonState State
        {
            get { return state; }
            set { state = mapper.Map<SingletonState>(value); }
        }

        public object GetRealObject(StreamingContext context)
        {
            SerializableSingleton singletonWithReference = SerializableSingleton.Instance;
            mapper.Map(State, singletonWithReference);
            return singletonWithReference;
        }

        private class SingletonState : ISingletonState
        {
            public string TestData { get; set; }
        }
    }
}
