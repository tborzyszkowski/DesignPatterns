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
public class Taniec implements Serializable{
    String nazwa;
    Taniec (String tekst){
        this.nazwa = tekst;
    }
    
    @Override
    public String toString(){
        return "Spotykanie się ze znajomymi w weekend w pubie, a następnie pójsć wyszaleć się do klubu";
    }
}
