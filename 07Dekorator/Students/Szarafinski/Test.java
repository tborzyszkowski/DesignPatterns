/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Dekorator;

/**
 *
 * @author KrzysieK
 */
public class Test {

    public static void main(String[] args) {
        Ksiazka ksiazka = new Ksiazka("Anioły i Demony", "Dan Brown");
        Ulotka ulotka = new Ulotka("Naucz się angielskiego w 2 tygodnie!");

        System.out.println("----");
        wydrukuj(ksiazka);
        wydrukuj(ulotka);

        System.out.println("----");
        Wydruk ksiazkaTwardaOkladkaWydrukKolor = new Papier(new Okladka(ksiazka, "Twarda"), "czarno-biały");
        wydrukuj(ksiazkaTwardaOkladkaWydrukKolor);
        System.out.println("----");
        Wydruk ulotkaCzarnoBiala = new Okladka(ulotka, "Kolor");
        wydrukuj(ulotkaCzarnoBiala);
        
    }

    public static void wydrukuj(Wydruk wydruk) {
        System.out.println(wydruk.pokaz() + "Cena: " + wydruk.wartosc() + "\n");
    }
}
