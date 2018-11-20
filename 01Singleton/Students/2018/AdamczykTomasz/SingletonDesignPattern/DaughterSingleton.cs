namespace SingletonDesignPattern
{
    public class DaughterSingleton : ParentSingleton<DaughterSingleton>
    {
        private DaughterSingleton() : base()
        {
        }
    }
}