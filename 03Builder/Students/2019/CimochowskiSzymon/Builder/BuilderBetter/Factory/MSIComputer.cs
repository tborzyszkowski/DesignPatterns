namespace Builder.BuilderBetter.Factory
{
    class MSIComputer : Computer
    {
        public MSIComputer()
        {
            Name = "MSI GP62 2QE Leopard Pro";
            Processor = "Intel Core i7-5700HQ";
            RAM = 16;
            GraphicsCard = "nVidia GeForce GTX 950M";
            PowerAdapter = 165;
            HardDrive = "Samsung EVO 950 M.2";
            HardDriveSpace = 256;
            Price = 4099;
        }
    }
}
