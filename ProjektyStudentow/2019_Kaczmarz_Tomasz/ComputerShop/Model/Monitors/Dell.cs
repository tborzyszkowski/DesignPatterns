namespace FactoryPattern.Model.Monitors
{
    class Dell : Monitor
    {
        public Dell()
        {
            Make = "Dell";
            Model = "U2717D";
            Resolution = "2560x1440";
            RefreshRate = 60;
        }
    }
}
