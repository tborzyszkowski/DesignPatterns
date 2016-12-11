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
abstract public class Sklep {
   // abstrakcyjna fabryka fabryk
   public abstract Komputer pobierz(TypKomputera typ);
    
    public Komputer wydaj(TypKomputera typ){
        Komputer komputer = pobierz(typ);
        komputer.przygotuj();
        komputer.pakuj();
        return komputer;
    }
    
            
}
