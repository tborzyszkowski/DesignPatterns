using System.IO;
using UI.Models;

namespace ChronoSortCore.Models
{
    public class ItemDecorator : AbstractItem
    {
        private AbstractItem _item;
        private ItemsCollection _parent;

        public new string CurrentPath
        {
            get
            {
                return this._item.CurrentPath;
            }
        }

        public new string NewPath
        {
            get
            {
                return this._item.NewPath;
            }
        }

        public ItemDecorator(AbstractItem item, ItemsCollection parent)
        {
            this._item = item;
            this._parent = parent;
        }

        public string GetNewPath()
        {
            var fileInfo = new FileInfo(this._item.CurrentPath);

            var fileName = this._parent.ItemList.IndexOf(this._item);

            return string.Format(@"{0}\{1}{2}", this._item.NewPath, fileName, fileInfo.Extension);
        }
    }
}
