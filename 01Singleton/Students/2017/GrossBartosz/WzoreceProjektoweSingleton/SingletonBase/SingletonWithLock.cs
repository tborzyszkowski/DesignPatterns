using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using WzoreceProjektoweSingleton.Utils;
using WzoreceProjektoweSingleton.Interfaces;

namespace WzoreceProjektoweSingleton.SingletonBase
{
    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public sealed class SingletonWithLock : IMessageInformer, IInstance<SingletonWithLock>, ISerializable
    {
        #region Constructor

        /// <summary>
        /// Initliaze Singleton With Lock.
        /// </summary>
        private SingletonWithLock()
        {
            counter = 1;
        }

        #endregion

        #region Fileds constans and properties

        /// <summary>
        /// The object name.
        /// </summary>
        private String name = "Object Singleton With Lock";

        /// <summary>
        /// The m_oInstance.
        /// </summary>
        private static SingletonWithLock m_oInstance;

        /// <summary>
        /// The m_oPadLock.
        /// </summary>
        private static readonly object m_oPadLock = new object();

        /// <summary>
        /// The counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// Gets the proper singleton instance.
        /// </summary>
        public static SingletonWithLock Instance
        {
            get
            {
                lock (m_oPadLock)
                {
                    if (m_oInstance == null)
                    {
                        m_oInstance = new SingletonWithLock();
                    }
                    return m_oInstance;
                }
            }
        }

        /// <summary>
        /// Gets the generic singleton instance.
        /// </summary>
        SingletonWithLock IInstance<SingletonWithLock>.GetInstance
        {
            get { return Instance; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add message to consol method.
        /// </summary>
        /// <param name="message">
        /// The string message.
        /// </param>
        public void AddMessage(string message)
        {
            Console.WriteLine($"Object:{name} message:{message}");
        }

        // A method called when serializing a Singleton.
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Instead of serializing this object,
            // serialize a SingletonSerializationHelp instead.
            info.SetType(typeof (SingletonWithLockSerializationHelper));
            // No other values need to be added.
        }

        #endregion
    }
}