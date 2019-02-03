namespace ConsoleApp1
{
    public sealed class Map
    {
        private static Map mapInstance;
        private static readonly object padlock = new object();
        private Map()
        {
        }

        public static Map MapInstance
        {
            get
            {
                if (mapInstance == null)
                {
                    lock (padlock)
                    {
                        if (mapInstance == null)
                        {
                            mapInstance = new Map();
                        }
                    }
                }
                return mapInstance;
            }
        }

        public Character[,] Fields = new Character[10,10];

        public void GenerateMap()
        {

        }

        public void PutOnMap(Character character)
        {

        }

        public Character GetNextField()
        {

        }
    }
}