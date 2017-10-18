using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using WzoreceProjektoweSingleton.SingletonBase;

namespace WzoreceProjektoweSingleton.Utils
{
    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    internal sealed class SingletonWithLockSerializationHelper : IObjectReference
    {
        // This object has no fields (although it could).
        // GetRealObject is called after this object is deserialized.
        public object GetRealObject(StreamingContext context)
        {
            // When deserialiing this object, return a reference to
            // the Singleton object instead.
            return SingletonWithLock.Instance;
        }
    }
}