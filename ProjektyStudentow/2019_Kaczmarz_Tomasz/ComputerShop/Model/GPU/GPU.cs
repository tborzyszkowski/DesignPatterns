namespace FactoryPattern.Model.GPU
{
    public abstract class GPU : IGear
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int CoreSpeed { get; set; }
        public int Memory { get; set; }

        public string Benchmark()
        {
            return string.Format("Karta graficzna {0} {1} osiągnęła {2} punktów w teście.", Make, Model, CoreSpeed * Memory);
        }

        public string GetSpecs()
        {
            return string.Format("Specyfikacja karty graficznej:\n Nazwa: {0} {1}\n Taktowanie rdzenia: {2}MHz\n Ilość pamięci: {3}GB", Make, Model, CoreSpeed, Memory);
        }
    }
}
