using ChronoSortCore.Interfaces;
using ChronoSortCore.Models;
using System.Collections.Generic;
using System.Linq;
using UI.Models;

namespace ChronoSortCore.Utils
{
    public class CollectionInterator : ICollectionIterator
    {
        private List<ItemDecorator> _collection;
        private int _current = 0;

        public CollectionInterator(List<ItemDecorator> collection)
        {
            this._collection = collection;
        }

        public ItemDecorator CurrentItem()
        {
            return this._collection[this._current];
        }

        public ItemDecorator First()
        {
            return this._collection.FirstOrDefault();
        }

        public ItemDecorator Next()
        {
            // Return the very next item which is available under specified location
            if (!this.CheckIndexCorrect())
            {
                return null;
            }
            while (!Validation.ValidateIfFileExists(this.CurrentItem().CurrentPath))
            {
                this._current++;

                if (!this.CheckIndexCorrect())
                {
                    return null;
                }
            }
            var currentItem = this.CurrentItem();
            this._current++;

            return currentItem;
        }

        private bool CheckIndexCorrect()
        {
            return this._current < this._collection.Count;
        }
    }
}
