/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Fasada;

import java.util.ArrayList;

/**
 *
 * @author KrzysieK
 */
public abstract class Danie {
    String nazwa;
    Double cena;
    ArrayList<String> skladniki = new ArrayList<>();
    
    @Override
    public String toString(){
        StringBuilder tekst = new StringBuilder();
        tekst.append(nazwa + " zawiera: \n");
        for (String skladnik : skladniki)
            tekst.append(skladnik + ", ");
        return tekst.toString();
    }
    
    public String wypiszSkladniki(){
        StringBuilder tekst = new StringBuilder();
        for (String skladnik : skladniki)
            tekst.append(skladnik + ", ");
        return tekst.toString();
    }
    
}
