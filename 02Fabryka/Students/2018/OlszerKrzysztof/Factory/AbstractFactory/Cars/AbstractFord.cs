namespace AbstractFactory.Cars
{
    public abstract class AbstractFord
    {
        public string Name;
        public int MaxSpeed;
        public int HP;

        public string prepare() => "Car.prepare()";
        public string getName() => Name;
        public string getMaxSpeed() => MaxSpeed + " km/h";
        public double getKW() => HP * 0.73;
        public string breakCar() => "200 m";

        public string drive()
        {
            string res = prepare();
            res +=" "+ getName()+ " " + getMaxSpeed()+ " " + getKW()+ " " + breakCar();

            return res;
        }
    }
}
