namespace FactoryMethod.Books
{
    public class MickiewiczStore : BookStore
    {
        private static MickiewiczStore mickiewiczStore;

        private MickiewiczStore() { }

        public static MickiewiczStore getInstance()
        {
            if (mickiewiczStore == null)
                mickiewiczStore = new MickiewiczStore();
            return mickiewiczStore;
        }

        public override Book createBook(string id)
        {
            if (id.ToUpper() == "SONETY")
                return new Sonety();
            else if (id.ToUpper() == "TADEUSZ")
                return new Tadeusz();
            return null;
        }
    }
}
