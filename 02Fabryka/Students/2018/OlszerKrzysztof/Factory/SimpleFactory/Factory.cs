using SimpleFactory.Books;
using SimpleFactory.Cars;
using SimpleFactory.Tanks;

namespace SimpleFactory
{
    public class Factory
    {
        private static Factory factory;

        private Factory() { }

        public static Factory getInstance()
        {
            if (factory == null)
                factory = new Factory();
            return factory;
        }

        public Book createBook(string id)
        {
            if (id.ToUpper() == "BALLADYNA")
                return new Balladyna();
            else if (id.ToUpper() == "KORDIAN")
                return new Kordian();
            else if (id.ToUpper() == "SONETY")
                return new Sonety();
            else if (id.ToUpper() == "TADEUSZ")
                return new Tadeusz();
            else if (id.ToUpper() == "ZMIJA")
                return new Zmija();

            return null;
        }

        public Car createCar(string id)
        {
            if (id.ToUpper() == "FIESTA")
                return new Fiesta();
            else if (id.ToUpper() == "ESCORT")
                return new Escort();
            else if (id.ToUpper() == "YARIS")
                return new Yaris();
            else if (id.ToUpper() == "AURIS")
                return new Auris();
            else if (id.ToUpper() == "FOCUS")
                return new Focus();

            return null;
        }
        public Tank createTank(string id)
        {
            if (id.ToUpper() == "TIGER")
                return new Tiger();
            else if (id.ToUpper() == "PANTHER")
                return new Panther();
            else if (id.ToUpper() == "MAUS")
                return new Maus();
            else if (id.ToUpper() == "ABRAMS")
                return new Abrams();
            else if (id.ToUpper() == "PERSHING")
                return new Pershing();

            return null;
        }
    }
}
