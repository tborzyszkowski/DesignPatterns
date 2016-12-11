/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactorySimple;

/**
 *
 * @author KrzysieK
 */
public class Fabryka {

    private static Fabryka fabryka;

    private Fabryka() {}; 
    
    public static synchronized Fabryka instancja() {
        if (fabryka == null) {
            fabryka = new Fabryka();
        }
        return fabryka;
    }

    public Komputer stworz(TypyKomputerow typ) {
        Komputer komputer = null;
        switch (typ) {
            case LAP223: {
                komputer = new Laptop223();
                break;
            }
            case LAP564: {
                komputer = new Laptop564();
                break;
            }
            case PC104: {
                komputer = new PC104();
                break;
            }
            case PC203: {
                komputer = new PC203();
                break;
            }
        }
        return komputer;
    }

}
