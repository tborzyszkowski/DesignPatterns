/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package projekt;

/**
 *
 * @author KrzysieK
 */
public class Klient {
    // singleton
    private volatile static Klient singleton = null;

    private Klient(String imie) {
        this.imie = imie;
    }
    private Klient() {
        this.imie = "Anonim";
    }

    
    public static Klient instancja() {
        if (singleton == null) {
            synchronized (Klient.class) {
                if (singleton == null) {
                    singleton = new Klient();
                }
            }
        }
        return singleton;
    }
    public static Klient instancja(String imie) {
        if (singleton == null) {
            synchronized (Klient.class) {
                if (singleton == null) {
                    singleton = new Klient(imie);
                }
            }
        }
        return singleton;
    }

    private String imie;

    public String getImie() {
        return imie;
    }

    @Override
    public String toString() {
         return "Nazywam się " + imie;
    }

}
