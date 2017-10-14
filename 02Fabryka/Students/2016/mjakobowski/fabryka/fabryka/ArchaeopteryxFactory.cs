namespace fabryka
{
    class ArchaeopteryxFactory : IDinoFactory
    {
        public Dino StworzDino(string imie)
        {
            return new Archaeopteryx() { Imie = imie };
        }
    }
}
