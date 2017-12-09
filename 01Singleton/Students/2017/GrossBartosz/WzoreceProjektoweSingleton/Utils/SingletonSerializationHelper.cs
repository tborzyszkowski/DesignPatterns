using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using WzoreceProjektoweSingleton.SingletonBase;

namespace WzoreceProjektoweSingleton.Utils
{
    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    internal sealed class SingletonSerializationHelper : IObjectReference
    {
        public Object GetRealObject(StreamingContext context)
        {
            return Singleton.Instance;
        }
    }
}
