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
public class SklepLap extends Sklep {
    Komputer komputer = null;
    
    MagazynCzesciKomputerowych magazyn = MagazynCzesciLaptop.instancja();
    
    
    @Override
    public Komputer pobierz(TypKomputera typ) {
        switch(typ){
            case LAPTOP:{
                komputer = new KomputerLaptop(magazyn);
                komputer.setModel("LAPTOP");
                break;
            }
            case LAPTOPzDodatkiem:{
                komputer = new KomputerLaptopzDodatkiem(magazyn);
                komputer.setModel("LAPTOP Z DODATKIEM");
                break;
            }
        }
        return komputer;
    }
}
