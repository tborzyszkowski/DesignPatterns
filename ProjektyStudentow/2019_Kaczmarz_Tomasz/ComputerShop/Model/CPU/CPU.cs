namespace ComputerShop.Model.CPU
{
    public abstract class CPU : IGear
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Clock { get; set; }
        public int Cores { get; set; }

        public string Benchmark()
        {
            return string.Format("Procesor {0} {1} osiągnął {2} punktów w teście.", Make, Model, Clock * Cores);
        }

        public string GetSpecs()
        {
            return string.Format("Specyfikacja procesora:\n Nazwa: {0} {1}\n Taktowanie: {2}MHz\n Liczba rdzeni: {3}", Make, Model, Clock, Cores);
        }
    }
}
