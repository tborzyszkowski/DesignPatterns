namespace Singleton
{
    public class SingletonC : SingletonA<SingletonC>
    {
        protected SingletonC() : base() { }
    }
}
