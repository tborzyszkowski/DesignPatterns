namespace FabrykaRefleksja
{
    public class Ford : Car
    {
        public Ford()
        {
            Producent = "Focus";
            Model = "Ford";
            PojemnoscSilnika = 2.0;
            Wlasciwosci.Add("TDI");
            Wlasciwosci.Add("Automatic gearbox");
        }
    }
}
