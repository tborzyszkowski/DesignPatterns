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
public class KomputerPCzDodatkiem extends Komputer {

    private MagazynCzesciKomputerowych magazyn;

    public KomputerPCzDodatkiem(MagazynCzesciKomputerowych magazyn) {
        this.magazyn = magazyn;
        skladaj();
    }

    public void skladaj() {
        System.out.println("Składanie komputera PC:");
        procesor = magazyn.wydajProcesor();
        monitor = magazyn.wydajMonitor();
        ram = magazyn.wydajRam();
        dodatek = magazyn.wydajDodatek();
    }
}
