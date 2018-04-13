namespace FactoryMethod.Cars
{
    public abstract class Car
    {
        protected string Name;
        protected int MaxSpeed;
        protected int HP;

        public string prepare() => "Car.prepare()";
        public string getName() => Name;
        public string getMaxSpeed() => MaxSpeed + " km/h";
        public double getKW() => HP * 0.73;
        public string breakCar() => "200 m";
    }
}
