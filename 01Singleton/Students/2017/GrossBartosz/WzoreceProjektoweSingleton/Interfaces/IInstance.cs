namespace WzoreceProjektoweSingleton.Interfaces
{
    public interface IInstance<T> where T : IMessageInformer
    {
        /// <summary>
        /// Gets the generic singleton instance.
        /// </summary>
        T GetInstance { get; }
    }
}
