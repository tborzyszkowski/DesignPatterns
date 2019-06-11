namespace FactoryPattern.Model.Monitors
{
    class Asus : Monitor
    {
        public Asus()
        {
            Make = "Asus";
            Model = "ROG PG258Q";
            Resolution = "1920x1080";
            RefreshRate = 240;
        }
    }
}
