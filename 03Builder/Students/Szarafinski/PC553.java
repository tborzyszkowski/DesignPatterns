/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Budowniczy;

/**
 *
 * @author KrzysieK
 */
public class PC553 extends zestawKomputerowy{
    public PC553(){
        komputer = new Komputer("Lenovo IdeaCentre");
    }

    @Override
    public zestawKomputerowy dodajProcsor() {
        komputer.procesor = new ProcesorI7();
        return this;
    }

    @Override
    public zestawKomputerowy dodajGrafike() {
       komputer.grafika = new GrafikaRadeon();
       return this;
    }

    @Override
    public zestawKomputerowy dodajRam() {
        komputer.ram = new Ram8();
        return this;
    }

    @Override
    public zestawKomputerowy dodajMonitor() {
        komputer.monitor = new Monitor17();
        return this;
    }
}
