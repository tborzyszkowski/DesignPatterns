package Adapter;

/**
 * Created by K.Karkucinski on 2016-12-29.
 */
public class FiatMultipla implements RodzinnySamochod {

    private int szybkosc = 190;
    private String kolor= "Różowy";

    public void spalaniePaliwa() {
        System.out.println("Spalanie paliwa: 6,5 l na 100 km");
    }

    public int getSzybkosc() {
        return szybkosc;
    }

    public String getKolor() {
        return kolor;
    }
}