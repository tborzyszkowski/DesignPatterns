/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

import java.util.HashMap;

/**
 *
 * @author KrzysieK
 */
public class BazaPracownikow {
    private HashMap<String,String> baza;
    
    public BazaPracownikow(){
        baza  = new HashMap<>();
        baza.put("Ludomir", "+48 504 965 01#");
    }
    
    public String pobierzTelefon(String imie){
        return baza.get(imie);
    }
    
    
    
}
