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
public class Osoba extends Prototyp implements Serializable {
    String imie;
    String nazwisko;
    Adres adres;
    Przedsiebiorstwo praca;
    Hobby hobby;
    
    Osoba (String imie, String nazwisko, String kodpocztowy, Przedsiebiorstwo praca, Hobby hobby){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.adres = new Adres(kodpocztowy);
        this.praca = praca;
        this.hobby = hobby;
    }
    
       
    public String przedstawSie(){
        StringBuffer tekst = new StringBuffer();
        tekst.append("Nazywam się " + imie + " " + nazwisko + ". \n");
        tekst.append("Mieszkam w " + adres.miasto + " przy ulicy " + adres.ulica + " " + adres.numer + "\n");
        tekst.append("Pracuję w " + praca.toString() + "\n");
        tekst.append("Moim hobby jest: " + hobby.toString());
        return tekst.toString();
    }
}
