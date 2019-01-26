namespace SingletonDesignPattern
{
    public class SonSingleton : ParentSingleton<SonSingleton>
    {
        private SonSingleton() : base()
        {
        }
    }
}