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
public class Ksiazka extends Wydruk {
    String autor;
    
    Ksiazka(String tytul, String autor){
        this.nazwa = tytul;
        rodzaj = "Ksiazka";
        this.autor = autor;
        this.cena = 20.0;
    }
    @Override
    public String pokaz() {
        StringBuffer tekst = new StringBuffer();
        tekst.append("Rodzaj: " + rodzaj + "\n");
        tekst.append("Nazwa: " + nazwa+ "\n");
        return tekst.toString();
    }

    @Override
    public Double wartosc() {
        return cena;
    }
    
}
