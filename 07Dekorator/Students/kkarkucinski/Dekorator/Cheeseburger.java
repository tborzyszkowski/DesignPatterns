package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class Cheeseburger extends Jedzenie {
    public Cheeseburger(){
        opis = "Cheeseburger";
    }

    @Override
    public double cena() {
        return 6.99;
    }
}

