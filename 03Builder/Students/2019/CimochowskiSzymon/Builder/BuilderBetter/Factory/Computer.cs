namespace Builder.BuilderBetter.Factory
{
    public abstract class Computer
    {
        public string Name { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }
        public string GraphicsCard { get; set; }
        public int PowerAdapter { get; set; }
        public string HardDrive { get; set; }
        public int HardDriveSpace { get; set; }
        public int Price { get; set; }
    }
}
