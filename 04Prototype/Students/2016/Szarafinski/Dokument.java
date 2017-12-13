/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Prototyp;

import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;

/**
 *
 * @author KrzysieK
 */
public class Dokument implements Serializable{
    Map<String, String> rejestZatrudnien = new HashMap<>();
        
    Dokument(){
        rejestZatrudnien.put("piekarz", "10-09-2010");
        rejestZatrudnien.put("kwiaciarka", "30-04-1999");
               
    }
    
    public String stan(String stanowisko){
        if (stanowisko.equalsIgnoreCase("piekarz") )
            return rejestZatrudnien.get(stanowisko);
        else if (stanowisko.equalsIgnoreCase("kwiaciarka") )
            return rejestZatrudnien.get(stanowisko);
        else
            return "b/d";
    }
}
