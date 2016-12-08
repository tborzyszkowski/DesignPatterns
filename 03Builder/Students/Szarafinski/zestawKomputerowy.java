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
public abstract class zestawKomputerowy {
    protected Komputer komputer;
    
      
    public Komputer nowyZestaw(){
        return this.dodajProcsor().dodajGrafike().dodajRam().dodajMonitor().komputer;
    }
    
    public abstract zestawKomputerowy dodajProcsor();
    public abstract zestawKomputerowy dodajGrafike ();
    public abstract zestawKomputerowy dodajRam ();
    public abstract zestawKomputerowy dodajMonitor ();
    
    
}
