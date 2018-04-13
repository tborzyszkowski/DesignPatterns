namespace FactoryMethod.Tanks
{
    class GermanStore : TankStore
    {
        private static GermanStore germanStore;

        private GermanStore() { }

        public static GermanStore getInstance()
        {
            if (germanStore == null)
                germanStore = new GermanStore();
            return germanStore;
        }

        public override Tank createTank(string id)
        {
            if (id.ToUpper() == "MAUS")
                return new Maus();
            else if (id.ToUpper() == "PANTHER")
                return new Panther();
            else if (id.ToUpper() == "TIGER")
                return new Tiger();
            return null;
        }
    }
}
