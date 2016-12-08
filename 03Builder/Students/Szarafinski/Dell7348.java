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
public class Dell7348 extends zestawKomputerowy {

    public Dell7348(){
        komputer = new Komputer("Dell Inspiron 13 7348");
    }
    @Override
    public zestawKomputerowy dodajProcsor() {
        komputer.procesor = new ProcesorI5();
        return this;
    }

    @Override
    public zestawKomputerowy dodajGrafike() {
        komputer.grafika = new GrafikaIntel();
         return this;
    }

    @Override
    public zestawKomputerowy dodajRam() {
         komputer.ram = new Ram8();
         return this;
    }

    @Override
    public zestawKomputerowy dodajMonitor() {
         komputer.monitor = new Monitor13();
         return this;
    }
    
}
