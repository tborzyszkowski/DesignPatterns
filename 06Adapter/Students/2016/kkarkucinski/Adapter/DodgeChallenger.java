package Adapter;

/**
 * Created by K.Karkucinski on 2016-12-29.
 */
public class DodgeChallenger implements SportowySamochod {
    private int szybkosc = 290;
    private String kolor= "Czerwony";

    public void spalanie() {
        System.out.println("Spalanie 13l na 100 km");
    }

    public int getSzybkosc() {
        return szybkosc;
    }

    public String getKolor() {
        return kolor;
    }
}
