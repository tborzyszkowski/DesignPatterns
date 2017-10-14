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
public class KomputerLaptop extends Komputer {
      private MagazynCzesciKomputerowych magazyn;
    
    public KomputerLaptop(MagazynCzesciKomputerowych magazyn){
        this.magazyn = magazyn;
        skladaj();
    }
    
    public void skladaj(){
        System.out.println("Składanie Laptopa:");
        procesor = magazyn.wydajProcesor();
        monitor = magazyn.wydajMonitor();
        ram = magazyn.wydajRam();
    }
}
