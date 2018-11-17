using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Singleton
{
    public class Program
    {
        private static readonly object MyLock2 = new object();
        static ShoppingList shoppingList = ShoppingList.ShoppingListInstance;
        static void Main()
        {
        }
        public static void Serialize(ShoppingList shoppingList)
        {
            lock (MyLock2)
            {
                BinaryFormatter binaryFmt = new BinaryFormatter();
                FileStream fs = new FileStream("D:/file.xml", FileMode.OpenOrCreate);
                binaryFmt.Serialize(fs, shoppingList);
                fs.Close();
            }
        }
        public static void Deserialize()
        {
            lock (MyLock2)
            {
                BinaryFormatter binaryFmt = new BinaryFormatter();
                FileStream fs = new FileStream("D:/file.xml", FileMode.OpenOrCreate);
                shoppingList = (ShoppingList)binaryFmt.Deserialize(fs);
                fs.Close();
            }
        }
    }
}
