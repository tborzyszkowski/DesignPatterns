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
public class Przelozony implements Serializable{
    String nazwa = "Jan Złoty";
    Dokument rocznikiZatrudnien;
    
    Przelozony(){
        rocznikiZatrudnien = new Dokument();
    }
    @Override
    public String toString(){
        return nazwa;
    }
}
