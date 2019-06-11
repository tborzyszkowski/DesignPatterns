namespace FactoryPattern.Model.CPU
{
    class Ryzen3 : CPU
    {
        public Ryzen3()
        {
            Make = "AMD";
            Model = "Ryzen 3 1300X";
            Cores = 4;
            Clock = 3700;
        }
    }
}
