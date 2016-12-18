package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class Hotdog extends Jedzenie {
    public Hotdog(){
        opis = "Hotdog";
    }

    @Override
    public double cena() {
        return 4.99;
    }
}

