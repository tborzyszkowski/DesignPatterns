namespace Mewa
{
    public interface ISamolot
    {
        bool WPowietrzu { get; }
        void Startowanie();
        int Wysokość { get; }
    }
}
