namespace AbstractFactory.Model
{
    public class Bike : BaseVehicle
    {
        public override string Name => "Bike";
        public override int Wheels => 2;
        public override bool HasEngine => false;
    }
}
