namespace FactoryMethod.Cars
{
    class ToyotaStore : CarStore
    {
        private static ToyotaStore toyotaStore;

        private ToyotaStore() { }

        public static ToyotaStore getInstance()
        {
            if (toyotaStore == null)
                toyotaStore = new ToyotaStore();
            return toyotaStore;
        }

        public override Car createCar(string id)
        {
            if (id.ToUpper() == "YARIS")
                return new Yaris();
            else if (id.ToUpper() == "AURIS")
                return new Auris();
            return null;
        }
    }
}
