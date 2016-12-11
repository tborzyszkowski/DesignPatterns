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
public class Okladka extends Dekorator {
    String rodzaj;
    public Okladka(Wydruk wydruk, String rodzaj) {
        super(wydruk);
        this.rodzaj = rodzaj;
    }
    
    @Override
    public String pokaz(){
        StringBuffer tekst = new StringBuffer(super.pokaz());
        tekst.append("Okładka: " + rodzaj + "\n");
        return tekst.toString();
    }
    
    @Override
    public Double wartosc(){
        return super.wartosc() + 7;
    }
}
