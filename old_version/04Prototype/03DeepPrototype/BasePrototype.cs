using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _03DeepPrototype {
	[Serializable()]
	public abstract class BasePrototype<T> {

		public T Clone() {
			return (T)this.MemberwiseClone();
		}

		public T DeepCopy() {
			T copy;
			using (MemoryStream stream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(stream, this);
				stream.Seek(0, SeekOrigin.Begin);
				copy = (T)formatter.Deserialize(stream);
			}
			return copy;
		}
	}
}
