namespace Singleton
{
    public class SingletonB : SingletonA<SingletonB>
    {
        protected SingletonB() : base() { }
    }
}
