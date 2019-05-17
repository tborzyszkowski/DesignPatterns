namespace Builder.BuilderBetter.Factory
{
    class AsusComputer : Computer
    {
        public AsusComputer()
        {
            Name = "ASUS GL503VM-ED300T";
            Processor = "Intel® Core™ i7-7700HQ";
            RAM = 16;
            GraphicsCard = "nVidia GeForce GTX 1060";
            PowerAdapter = 205;
            HardDrive = "GOODRAM CX400";
            HardDriveSpace = 256;
            Price = 5999;
        }
    }
}
