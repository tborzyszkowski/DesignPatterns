namespace Builder.BuilderBetter.Builder
{
    class AsusBuilder : ComputerBuilder
    {
        public AsusBuilder()
        {
            _computerUnit = CreateComputer();
        }

        public override Computer CreateComputer()
        {
            return new Computer() {Name = "ASUS GL503VM-ED300T"};
        }

        public override ComputerBuilder SetProcessor()
        {
            _computerUnit.Processor = "Intel® Core™ i7-7700HQ";
            return this;
        }

        public override ComputerBuilder SetRAM()
        {
            _computerUnit.RAM = 16;
            return this;
        }

        public override ComputerBuilder SetGraphicsCard()
        {
            _computerUnit.GraphicsCard = "nVidia GeForce GTX 1060";
            return this;
        }

        public override ComputerBuilder SetPowerAdapter()
        {
            _computerUnit.PowerAdapter = 205;
            return this;
        }

        public override ComputerBuilder SetHardDrive()
        {
            _computerUnit.HardDrive = "GOODRAM CX400";
            return this;
        }

        public override ComputerBuilder SetHardDriveSpace()
        {
            _computerUnit.HardDriveSpace = 256;
            return this;
        }

        public override ComputerBuilder SetPrice()
        {
            _computerUnit.Price = 5999;
            return this;
        }
    }
}
