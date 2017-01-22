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
public class Cukiernia {

    private static Cukiernia fabryka = null;
    private static HashMap<String, Deser> slownik = new HashMap<>();

    private Cukiernia() {
        slownik.put("dod Kawy", new Drozdzowka());
        slownik.put("na droge", new Paczek());
    }
    
    public synchronized static Cukiernia instancja() {
        if (fabryka == null) {
            fabryka = new Cukiernia();
        }
        return fabryka;
    }

    public Deser zamowDeser(String opis) {
        return slownik.getOrDefault(opis, new Paczek());
    }

}
