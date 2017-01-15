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
public class Narrator {
    String lektor;
       private static Narrator fabryka = null;
    private static HashMap<String, Bajka> slownik = new HashMap<>();

    private Narrator() {
        lektor = "Krystian Czubówna";
        slownik.put("COOL RESTARANT", new COOL_RESTAURANT(lektor));
        
    }
    
    public synchronized static Narrator instancja() {
        if (fabryka == null) {
            fabryka = new Narrator();
        }
        return fabryka;
    }

    public Bajka zamowBajke(String tytul) {
        return slownik.getOrDefault(tytul, new COOL_RESTAURANT(lektor));
    }
}
