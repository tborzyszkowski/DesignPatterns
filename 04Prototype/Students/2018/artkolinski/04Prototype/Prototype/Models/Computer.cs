namespace Prototype.Models
{
    public class Computer : ComputerPrototype
    {
        public Computer(Motherboard motherboard)
        {
            Motherboard = motherboard;
        }
        public string ProjectName { get; set; }
        public string Case { get; set; }
        public Motherboard Motherboard { get; set; }
        public override ComputerPrototype DeepClone()
        {
            var motherboard = new Motherboard
            {
                Processor = Motherboard.Processor,
                GraphicCard = Motherboard.GraphicCard,
                Memory = Motherboard.Memory
            };
            return new Computer(motherboard)
            {
                ProjectName = ProjectName,
                Case = Case
            };
        }
        public override object ShallowClone()
        {
            return MemberwiseClone();
        }
    }
}
