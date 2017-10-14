namespace fabryka
{
    class BrontosaurusFactory : IDinoFactory
    {
        public Dino StworzDino(string imie)
        {
            return new Brontosaurus() { Imie = imie };
        }
    }
}
