namespace ChronoSortCore.Interfaces
{
    interface ILogger
    {
        void Error(string text);

        void Warning(string text);

        void Info(string text);
    }
}
