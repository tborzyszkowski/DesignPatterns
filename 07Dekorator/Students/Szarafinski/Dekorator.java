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
public abstract class Dekorator extends Wydruk{
    Wydruk wydruk;
    
    Dekorator(Wydruk wydruk){
        this.wydruk = wydruk;
    }
    @Override
    public String pokaz() {
        return wydruk.pokaz();
    }

    @Override
    public Double wartosc() {
     return wydruk.wartosc();
    }
    
}
