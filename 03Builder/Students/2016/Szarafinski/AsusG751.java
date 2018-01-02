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
public class AsusG751 extends zestawKomputerowy {
    public AsusG751(){
        komputer = new Komputer("Asus G751");
    }

    @Override
    public zestawKomputerowy dodajProcsor() {
        komputer.procesor = new ProcesorI7();
        return this;
    }

    @Override
    public zestawKomputerowy dodajGrafike() {
        komputer.grafika = new GrafikaGeForceGTX960();
        return this;
    }

    @Override
    public zestawKomputerowy dodajRam() {
        komputer.ram = new Ram16();
        return this;
    }

    @Override
    public zestawKomputerowy dodajMonitor() {
        komputer.monitor = new Monitor17();
        return this;
    }
  
    
}
