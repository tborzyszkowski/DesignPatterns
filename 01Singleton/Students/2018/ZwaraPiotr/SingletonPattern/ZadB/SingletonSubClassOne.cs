namespace SingletonPattern.ZadB
{
    public class SingletonSubClassOne : SingletonBaseClass<SingletonSubClassOne>
    {
        private SingletonSubClassOne()
            : base() { }
    }
}
