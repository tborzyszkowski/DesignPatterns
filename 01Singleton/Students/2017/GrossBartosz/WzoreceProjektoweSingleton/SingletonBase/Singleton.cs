using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using WzoreceProjektoweSingleton.Utils;
using WzoreceProjektoweSingleton.Interfaces;

namespace WzoreceProjektoweSingleton.SingletonBase
{
    [Serializable]
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class Singleton : IMessageInformer, IInstance<Singleton>, ISerializable
    {
        #region Constructor

        /// <summary>
        /// Initliaze singleton.
        /// </summary>
        protected Singleton()
        {
        }

        #endregion

        #region Fileds constans and properties

        /// <summary>
        /// The object name.
        /// </summary>
        private String name = "Singleton";

        /// <summary>
        /// The counter.
        /// </summary>
        public static int Id = 1;

        /// <summary>
        /// Gets the proper singleton instance.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                return Nested.ReturnInstance();
            }
        }

        /// <summary>
        /// Gets the generic singleton instance.
        /// </summary>
        Singleton IInstance<Singleton>.GetInstance
        {
            get
            {
                return Instance;
            }
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

        /// <summary>
        /// The get name method.
        /// </summary>
        /// <returns>
        /// Returns the name of the object <see cref="string"/>
        /// </returns>
        public virtual string GetName()
        {
            return ($"Object:{name}");
        }

        /// <summary>
        /// A method called when serializing a Singleton.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The contex.
        /// </param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SingletonSerializationHelper));
        }

        #endregion

        #region Nested class

        /// <summary>
        /// The Nested class.
        /// </summary>
        private class Nested
        {
            /// <summary>
            /// Explicit static constructor to tell C# compiler, not to mark type as beforefieldinit.
            /// </summary>
            static Nested()
            {
            }

            /// <summary>
            /// The singleton instance.
            /// </summary>
            private static Singleton instance = null;

            public static Singleton ReturnInstance()
            {
                if (instance == null)
                {
                    instance = new Singleton();
                    Console.WriteLine($"Singleton initialized time{Singleton.Id}");
                }
                Id++;
                return instance;
            }
        }
        #endregion
    }
}
