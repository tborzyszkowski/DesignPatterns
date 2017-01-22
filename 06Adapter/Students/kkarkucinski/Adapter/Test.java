package Adapter;

/**
 * Created by K.Karkucinski on 2016-12-29.
 */
public class Test {
    public static void main(String[]args){
        SportowySamochod challenger = new DodgeChallenger();
        RodzinnySamochod multipla = new FiatMultipla();
        SportowySamochod adapterrodzinnego = new AdapterRodzinny(multipla);

        System.out.println("Samochód sportowy:");
        System.out.println("Predkość naszego samochodu to : "+challenger.getSzybkosc());
        challenger.spalanie();
        System.out.println(challenger.getKolor()+"\n");


        System.out.println("Samochód rodzinny:");
        System.out.println("Predkość naszego samochodu to : "+multipla.getSzybkosc());
        multipla.spalaniePaliwa();
        System.out.println(multipla.getKolor()+"\n");


        System.out.println("Samochód rodzinny adaptowany na sportowy:");
        System.out.println("Predkość naszego samochodu to : "+adapterrodzinnego.getSzybkosc());
        adapterrodzinnego.spalanie();
        System.out.println(adapterrodzinnego.getKolor()+"\n");

    }
}
