using Factory.Models;

namespace Factory
{
    public class SimpleDeviceFactory
    {
        public Device CreateDevice(string type)
        {
            if (type.Equals("Smartphone"))
            {
                return new Smartphone();
            }
            else if (type.Equals("Tablet"))
            {
                return new Tablet();
            }
            else if (type.Equals("BookReader"))
            {
                return new BookReader();
            }
            return null;
        }
    }
}
