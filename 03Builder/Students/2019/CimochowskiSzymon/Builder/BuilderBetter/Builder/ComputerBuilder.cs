namespace Builder.BuilderBetter.Builder
{
    public abstract class ComputerBuilder
    {
        protected Computer _computerUnit;

        public Computer Computer => _computerUnit;

        public abstract Computer CreateComputer();
        public abstract ComputerBuilder SetProcessor();
        public abstract ComputerBuilder SetRAM();
        public abstract ComputerBuilder SetGraphicsCard();
        public abstract ComputerBuilder SetPowerAdapter();
        public abstract ComputerBuilder SetHardDrive();
        public abstract ComputerBuilder SetHardDriveSpace();
        public abstract ComputerBuilder SetPrice();

        public static implicit operator Computer(ComputerBuilder epicBuild)
        {
            return epicBuild.SetProcessor()
                .SetRAM()
                .SetGraphicsCard()
                .SetPowerAdapter()
                .SetHardDrive()
                .SetHardDriveSpace()
                .SetPrice()
                .Computer;
        }
    }
}
