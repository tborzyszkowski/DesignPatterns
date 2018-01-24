namespace ChronoSortCore.Parameters
{
    public abstract class Parameter
    {
        public string ShortOption { get; set; }

        public string LongOption { get; set; }

        public string Value { get; set; }

        public abstract bool Validate();

        public abstract void Execute();

        public abstract string GetUsage();
    }
}
