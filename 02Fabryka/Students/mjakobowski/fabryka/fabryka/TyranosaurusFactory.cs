namespace fabryka
{
    class TyranosaurusFactory : IDinoFactory
    {
        public Dino StworzDino(string imie)
        {
            return new Tyranosaurus() { Imie = imie };
        }
    }
}
