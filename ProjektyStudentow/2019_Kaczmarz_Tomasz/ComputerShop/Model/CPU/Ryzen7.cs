namespace FactoryPattern.Model.CPU
{
    class Ryzen7 : CPU
    {
        public Ryzen7()
        {
            Make = "AMD";
            Model = "Ryzen 7 2700X";
            Cores = 8;
            Clock = 4300;
        }
    }
}
