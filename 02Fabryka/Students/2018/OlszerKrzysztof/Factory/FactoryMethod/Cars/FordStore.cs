namespace FactoryMethod.Cars
{
    class FordStore : CarStore
    {
        private static FordStore fordStore;

        private FordStore() { }

        public static FordStore getInstance()
        {
            if (fordStore == null)
                fordStore = new FordStore();
            return fordStore;
        }

        public override Car createCar(string id)
        {
            if (id.ToUpper() == "FIESTA")
                return new Fiesta();
            else if (id.ToUpper() == "FOCUS")
                return new Focus();
            else if (id.ToUpper() == "ESCORT")
                return new Escort();
            return null;
        }
    }
}
