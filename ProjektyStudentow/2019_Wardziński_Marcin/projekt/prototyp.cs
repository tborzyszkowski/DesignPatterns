using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace projekt
{
    [Serializable]
    public abstract class prototyp<T> where T : class
    {
        public T kopiuj()
        {
            using (var strumien = new MemoryStream())
            {
                var forma = new BinaryFormatter();
                forma.Serialize(strumien, this);
                strumien.Position = 0;
                return forma.Deserialize(strumien) as T;
            }
        }
    }
}
