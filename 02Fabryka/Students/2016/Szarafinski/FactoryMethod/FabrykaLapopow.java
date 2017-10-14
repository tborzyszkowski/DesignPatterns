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
public class FabrykaLapopow extends Sklep {

    private static FabrykaLapopow fabryka = null;

    private FabrykaLapopow() {} ;
    
    public synchronized static FabrykaLapopow instancja() {
        if (fabryka == null) {
            fabryka = new FabrykaLapopow();
        }
        return fabryka;
    }

    @Override
    public Komputer pobierz(TypKomputera typ) {
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
        }
        return komputer;
    }
}
