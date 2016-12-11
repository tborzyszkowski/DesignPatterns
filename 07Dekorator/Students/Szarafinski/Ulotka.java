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
public class Ulotka extends Wydruk {
    Integer sztuki;
    Ulotka(String nazwa){
        this.rodzaj = "Ulotka";
        this.cena = 10.0;
        this.nazwa = nazwa;
        this.sztuki = 1000;
    }
    @Override
    public String pokaz() {
        StringBuffer tekst = new StringBuffer();
        tekst.append("Rodzaj: " + rodzaj + "\n");
        tekst.append("Nazwa: " + nazwa+ "\n");
        tekst.append("Liczba sztuk: " + sztuki+ "\n");
        return tekst.toString();
    }

    @Override
    public Double wartosc() {
        return cena;
    }
    
}
