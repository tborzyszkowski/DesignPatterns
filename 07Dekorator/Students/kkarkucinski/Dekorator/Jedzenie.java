package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public abstract class Jedzenie {
    String opis = "Brak opisu";

    public String dodajOpis(){
        return opis;
    }
    public abstract double cena();
}
