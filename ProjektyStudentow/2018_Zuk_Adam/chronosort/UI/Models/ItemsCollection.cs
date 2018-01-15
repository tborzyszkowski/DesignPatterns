using System.Collections.Generic;
using System.Xml.Serialization;

namespace UI.Models
{
    public class ItemsCollection
    {
        [XmlArray("ItemList"), XmlArrayItem(typeof(Item), ElementName = "Item")]
        public List<AbstractItem> ItemList { get; set; }

        public ItemsCollection()
        {
            this.ItemList = new List<AbstractItem>();
        }
    }
}
