namespace AbstractFactory.Model
{
    public class Motorbike : BaseVehicle
    {
        public override string Name => "Motorbike";
        public override int Wheels => 2;
        public override bool HasEngine => true;
    }
}
