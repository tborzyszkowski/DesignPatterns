namespace FactoryMethod.Tanks
{
    class USAStore : TankStore
    {
        private static USAStore usaStore;

        private USAStore() { }

        public static USAStore getInstance()
        {
            if (usaStore == null)
                usaStore = new USAStore();
            return usaStore;
        }

        public override Tank createTank(string id)
        {
            if (id.ToUpper() == "ABRAMS")
                return new Abrams();
            else if (id.ToUpper() == "PERSHING")
                return new Pershing();
            return null;
        }
    }
}
