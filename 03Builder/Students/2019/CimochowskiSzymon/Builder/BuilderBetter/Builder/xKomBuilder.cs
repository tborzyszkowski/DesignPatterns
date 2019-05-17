namespace Builder.BuilderBetter.Builder
{
    class xKomBuilder : ComputerBuilder
    {
        public xKomBuilder()
        {
            _computerUnit = CreateComputer();
        }

        public override Computer CreateComputer()
        {
            return new Computer() {Name = "x-kom G4M3R 500"};
        }

        public override ComputerBuilder SetProcessor()
        {
            _computerUnit.Processor = "Intel Core i5-9400F";
            return this;
        }

        public override ComputerBuilder SetRAM()
        {
            _computerUnit.RAM = 32;
            return this;
        }

        public override ComputerBuilder SetGraphicsCard()
        {
            _computerUnit.GraphicsCard = "nVidia GeForce GTX 1060 Desktop";
            return this;
        }

        public override ComputerBuilder SetPowerAdapter()
        {
            _computerUnit.PowerAdapter = 700;
            return this;
        }

        public override ComputerBuilder SetHardDrive()
        {
            _computerUnit.HardDrive = "Crucial BX500";
            return this;
        }

        public override ComputerBuilder SetHardDriveSpace()
        {
            _computerUnit.HardDriveSpace = 120;
            return this;
        }

        public override ComputerBuilder SetPrice()
        {
            _computerUnit.Price = 3599;
            return this;
        }
    }
}
