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
public class MagazynCzesciPC implements MagazynCzesciKomputerowych {
    private static MagazynCzesciPC magazyn = null;
    private MagazynCzesciPC(){};
    
    public static MagazynCzesciPC instancja(){
        if (magazyn == null ){
            magazyn = new MagazynCzesciPC();
        }
        return magazyn;
    }
    
    @Override
    public Ram wydajRam() {
        return new Ram8();
    }

    @Override
    public Monitor wydajMonitor() {
        return new Monitor17();
    }

    @Override
    public Procesor wydajProcesor() {
        return new ProcesorI5();
    }
    @Override
    public Dodatek wydajDodatek(){
        return new DodatekMysz();
    }
}
