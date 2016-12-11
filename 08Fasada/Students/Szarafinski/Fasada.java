/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Fasada;

/**
 *
 * @author KrzysieK
 */
public class Fasada {

    Obiad obiad;
    Pizza pizza;
    Kuchnia kuchnia;
    Kasa kasa;
    Dostawa pizzamen;
    Serwis serwis;

    Fasada() {
        pizza = new Pizza();
        obiad = new Obiad();
        kuchnia = new Kuchnia();
        kasa = new Kasa();
        serwis = new Serwis();
        pizzamen = new Dostawa();
    }

    public void zamow(Zamowienie zamowienie, String lokalizacja) {
        switch (zamowienie) {
            case PIZZA: {
                zamowPizze(lokalizacja);
                break;
            }
            case OBIAD: {
                zamowObiad(lokalizacja);
                break;
            }
        }
    }

    private void zamowPizze(String lokalizacja) {
        if (kasa.czyZaplacone()) {
            kuchnia.przygotuj(pizza);
            kuchnia.dodajSkladniki(pizza);
            kuchnia.upiecz(pizza);
            serwis.zapakuj(pizza);
            pizzamen.dostarcz(pizza, lokalizacja);
        } else {
            System.out.println("Nie zapłacono");
        }
    }

    private void zamowObiad(String lokalizacja) {
        if (kasa.czyZaplacone()) {
            kuchnia.przygotuj(obiad);
            kuchnia.dodajSkladniki(obiad);
            kuchnia.upiecz(obiad);
            serwis.zapakuj(obiad);
            pizzamen.dostarcz(obiad, lokalizacja);
        } else {
            System.out.println("Nie zapłacono");
        }
    }

   
}
