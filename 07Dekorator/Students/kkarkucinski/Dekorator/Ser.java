package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class Ser extends Dodatki {
    Jedzenie jedzenie;

    public Ser (Jedzenie jedzenie){
        this.jedzenie = jedzenie;
    }
    @Override
    public String dodajOpis() {
        return jedzenie.dodajOpis()+", dodatkowy ser";
    }

    @Override
    public double cena() {
        return jedzenie.cena()+1.5;
    }
}
