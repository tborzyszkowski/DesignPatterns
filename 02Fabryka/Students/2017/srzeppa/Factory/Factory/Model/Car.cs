namespace Factory.Model
{
    public class Car : BaseVehicle
    {
        public override string Name => "Car";
        public override int Wheels => 4;
        public override bool HasEngine => true;
    }
}
