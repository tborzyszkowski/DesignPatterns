namespace SingletonPattern.ZadB
{
    public class SingletonSubClassTwo : SingletonBaseClass<SingletonSubClassTwo>
    {
        private SingletonSubClassTwo()
            : base() { }
    }
}
