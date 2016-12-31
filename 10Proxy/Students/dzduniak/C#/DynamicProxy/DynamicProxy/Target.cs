namespace DynamicProxy
{
    public class Target : ISomeInterface
    {
        public string Method1()
        {
            return this.GetType().Name + ": Tu metoda nr 1!";
        }

        public string Method2()
        {
            return this.GetType().Name + ": Tu metoda nr 2!";
        }
    }
}