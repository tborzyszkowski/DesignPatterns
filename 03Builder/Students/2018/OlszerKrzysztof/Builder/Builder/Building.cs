using System;

namespace Builder
{
    public class Building
    {
        public string buildingType { get; }
        public int windows { get; set; }
        public int doors { get; set; }
        public int floors { get; set; }
        public string color { get; set; }

        public Building(string type)
        {
            buildingType = type;
        }

        public void Show()
        {
            Console.WriteLine("Building Type: {0}", buildingType);
            Console.WriteLine(" Windows : {0}", windows);
            Console.WriteLine(" Doors : {0}", doors);
            Console.WriteLine(" Floors: {0}", floors);
            Console.WriteLine(" Color : {0}", color);
        }
    }
}
