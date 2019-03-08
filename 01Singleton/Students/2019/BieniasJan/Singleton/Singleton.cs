//Jan Bienias 238201

namespace Singleton
{
    public class Singleton : GenericSingleton<Singleton>
    {
        private Singleton() : base()
        {

        }
    }
}
