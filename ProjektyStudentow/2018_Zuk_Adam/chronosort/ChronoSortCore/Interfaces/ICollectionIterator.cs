using ChronoSortCore.Models;
using UI.Models;

namespace ChronoSortCore.Interfaces
{
    public interface ICollectionIterator
    {
        ItemDecorator First();

        ItemDecorator Next();

        ItemDecorator CurrentItem();
    }
}
