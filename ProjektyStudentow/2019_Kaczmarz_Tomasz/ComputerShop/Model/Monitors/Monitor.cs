namespace ComputerShop.Model.Monitors
{
    public abstract class Monitor : IGear
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Resolution { get; set; }
        public int RefreshRate { get; set; }

        public string GetSpecs()
        {
            return string.Format("Specyfikacja monitora:\n Nazwa: {0} {1}\n Rozdzielczość: {2}\n Odświeżanie: {3}Hz", Make, Model, Resolution, RefreshRate);
        }
    }
}
