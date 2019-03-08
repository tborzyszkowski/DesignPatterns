//Jan Bienias 238201

namespace Singleton
{
    public class AnotherSingleton : GenericSingleton<AnotherSingleton>
    {
        protected AnotherSingleton() : base()
        {

        }
    }
}
