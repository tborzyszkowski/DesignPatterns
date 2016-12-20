package Dekorator;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class Salata extends Dodatki{
    Jedzenie jedzenie;

    public Salata (Jedzenie jedzenie){
        this.jedzenie = jedzenie;
    }
    @Override
    public String dodajOpis() {
        return jedzenie.dodajOpis()+", dodatkowa Sałata";
    }

    @Override
    public double cena() {
        return jedzenie.cena()+0.8;
    }
}