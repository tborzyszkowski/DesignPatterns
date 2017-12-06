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
public class Przedsiebiorstwo implements Serializable{
    String stanowisko;
    String nazwa = "FHU Zdobywca";
    Przelozony szef;
    
    Przedsiebiorstwo(String nazwa){
        this.stanowisko = nazwa;
        this.szef = new Przelozony();
    }
    
    @Override
    public String toString(){
        StringBuffer tekst = new StringBuffer();
        tekst.append(nazwa + "na stanowisku: " + stanowisko + "\n");
        tekst.append("Moim przełożonym jest " + szef.toString() + "\n");
        tekst.append("Pracuję od dnia: " + szef.rocznikiZatrudnien.stan(stanowisko));
        return tekst.toString();
    }
    
}
