namespace FactoryMethod.Books
{
    public class SlowackiStore : BookStore
    {
        private static SlowackiStore slowackiStore;

        private SlowackiStore() { }

        public static SlowackiStore getInstance()
        {
            if (slowackiStore == null)
                slowackiStore = new SlowackiStore();
            return slowackiStore;
        }

        public override Book createBook(string id)
        {
            if (id.ToUpper() == "BALLADYNA")
                return new Balladyna();
            else if (id.ToUpper() == "KORDIAN")
                return new Kordian();
            else if (id.ToUpper() == "ZMIJA")
                return new Zmija();
            return null;
        }
    }
}
