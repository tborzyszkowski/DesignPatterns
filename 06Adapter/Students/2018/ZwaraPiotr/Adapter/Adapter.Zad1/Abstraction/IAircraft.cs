namespace Adapter.Zad1.Abstraction
{
    public interface IAircraft
    {
        bool Airborne { get; }
        int Height { get; set; } // added set :)
        void TakeOff();
    }
}
