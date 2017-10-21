namespace SingletonSerialization.Interfaces
{
    public interface ILogger
    {
        bool Serialize(string fileName);

        void Log(string text);
    }
}
