/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Prototyp;

import java.io.Serializable;

/**
 *
 * @author KrzysieK
 */
public class Adres implements Serializable{
    String miasto;
    String ulica;
    int numer;
    
    Adres(String kod){
        zweryfikuj(kod);
        this.numer = (int) (Math.random() * 100);
    }
    
    void zweryfikuj(String kod){
        if (kod.equalsIgnoreCase("80-456")){
           miasto = "Gdańsk";
           ulica = "Adolfa Dygasińskiego";
        } else if (kod.equalsIgnoreCase("54-318")){
            miasto = "Wrocław";
            ulica = "Marianowska";
        } else {
            miasto = "Warszawa";
            ulica = "Matejki";
        }
    }
    
    @Override
    public String toString(){
        StringBuffer tekst = new StringBuffer();
        tekst.append("Mieszkam w " + miasto + " przy ulicy " + ulica + " " + numer);
        return tekst.toString();
    }
    
    
}
