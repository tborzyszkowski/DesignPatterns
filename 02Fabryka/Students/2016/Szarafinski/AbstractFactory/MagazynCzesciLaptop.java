/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactoryAbstract;

/**
 *
 * @author KrzysieK
 */
public class MagazynCzesciLaptop implements MagazynCzesciKomputerowych {

    private static MagazynCzesciLaptop magazyn = null;

    private MagazynCzesciLaptop() {};
    
    public static MagazynCzesciLaptop instancja() {
        if (magazyn == null) {
            magazyn = new MagazynCzesciLaptop();
        }
        return magazyn;
    }

    @Override
    public Ram wydajRam() {
        return new Ram4();
    }

    @Override
    public Monitor wydajMonitor() {
       return new Monitor10();
    }
    @Override
    public Procesor wydajProcesor() {
        return new ProcesorI3();
    }
    @Override
    public Dodatek wydajDodatek(){
        return new DodatekTorba();
    }
    
}
