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
public class Rower implements Serializable{
    String nazwa;
    Rower (String tekst){
        this.nazwa = tekst;
    }
    
    @Override
    public String toString(){
        return "Jazda na rowerze po górach i dolinach po pracy";
    }
}
