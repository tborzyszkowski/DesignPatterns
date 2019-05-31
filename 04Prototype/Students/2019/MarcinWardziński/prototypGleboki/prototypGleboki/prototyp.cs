using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace prototypGleboki
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
