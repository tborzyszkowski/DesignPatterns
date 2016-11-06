namespace FabrykaRefleksja
{
    public class Vw : Car
    {
        public Vw()
        {
            Producent = "Vw";
            Model = "Golf";
            PojemnoscSilnika = 1.6;
            Wlasciwosci.Add("Benzyna");
            Wlasciwosci.Add("Manual gearbox");
        }
    }
}
