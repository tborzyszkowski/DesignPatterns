namespace Builder.BuilderBetter.Builder
{
    class MSIBuilder : ComputerBuilder
    {
        public MSIBuilder()
        {
            _computerUnit = CreateComputer();
        }

        public override Computer CreateComputer()
        {
            return new Computer() {Name = "MSI GP62 2QE Leopard Pro"};
        }

        public override ComputerBuilder SetProcessor()
        {
            _computerUnit.Processor = "Intel Core i7-5700HQ";
            return this;
        }

        public override ComputerBuilder SetRAM()
        {
            _computerUnit.RAM = 16;
            return this;
        }

        public override ComputerBuilder SetGraphicsCard()
        {
            _computerUnit.GraphicsCard = "nVidia GeForce GTX 950M";
            return this;
        }

        public override ComputerBuilder SetPowerAdapter()
        {
            _computerUnit.PowerAdapter = 165;
            return this;
        }

        public override ComputerBuilder SetHardDrive()
        {
            _computerUnit.HardDrive = "Samsung EVO 950 M.2";
            return this;
        }

        public override ComputerBuilder SetHardDriveSpace()
        {
            _computerUnit.HardDriveSpace = 256;
            return this;
        }

        public override ComputerBuilder SetPrice()
        {
            _computerUnit.Price = 4099;
            return this;
        }
    }
}
