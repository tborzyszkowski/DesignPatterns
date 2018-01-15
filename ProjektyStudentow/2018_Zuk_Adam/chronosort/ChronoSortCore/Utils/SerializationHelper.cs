using ChronoSortCore.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UI.Models;

namespace ChronoSortCore.Utils
{
    public class SerializationHelper
    {
        public static List<ItemDecorator> Deserialize(string path)
        {
            ItemsCollection collection = null;

            using (var reader = new StreamReader(path))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(ItemsCollection));
                collection = (ItemsCollection)deserializer.Deserialize(reader);
            }

            var itemList = new List<ItemDecorator>();

            foreach (var item in collection.ItemList)
            {
                itemList.Add(new ItemDecorator(item, collection));
            }

            return itemList;
        }
    }
}
