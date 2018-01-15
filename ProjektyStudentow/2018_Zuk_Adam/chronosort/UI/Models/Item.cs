using System.Xml.Serialization;

namespace UI.Models
{
    [XmlRoot("Item")]
    public class Item : AbstractItem
    {
        public Item()
        {

        }

        public Item(string currPath, string newPath)
        {
            this.CurrentPath = currPath;
            this.NewPath = newPath;
        }
    }
}
