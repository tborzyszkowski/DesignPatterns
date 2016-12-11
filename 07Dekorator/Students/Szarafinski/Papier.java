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
public class Papier extends Dekorator {
    String kolor;
    public Papier(Wydruk wydruk, String kolor) {
        super(wydruk);
        this.kolor = kolor;
    }
    @Override
    public String pokaz(){
        super.cena = wartosc();
        StringBuffer tekst = new StringBuffer(super.pokaz());
        tekst.append("Papier: " + kolor + "\n");
        return tekst.toString();
    }
    
    @Override
    public Double wartosc(){
        return super.wartosc() + 4;
    }
}
