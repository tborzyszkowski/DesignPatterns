package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class Cebula extends Dodatki {
    Jedzenie jedzenie;

    public Cebula (Jedzenie jedzenie){
        this.jedzenie = jedzenie;
    }
    @Override
    public String dodajOpis() {
        return jedzenie.dodajOpis()+", dodatkowa cebula";
    }

    @Override
    public double cena() {
        return jedzenie.cena()+1.0;
    }
}