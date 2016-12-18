/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactoryMethod;

/**
 *
 * @author KrzysieK
 */
public class FabrykaPC extends Sklep {

    private static FabrykaPC fabryka = null;

    private FabrykaPC() {};
    
    public synchronized static FabrykaPC instancja() {
        if (fabryka == null) {
            fabryka = new FabrykaPC();
        }
        return fabryka;
    }

    @Override
    public Komputer pobierz(TypKomputera typ) {

        Komputer komputer = null;
        switch (typ) {
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
