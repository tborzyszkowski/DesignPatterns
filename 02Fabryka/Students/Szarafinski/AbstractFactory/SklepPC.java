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
public class SklepPC extends Sklep {
    Komputer komputer = null;
    
    MagazynCzesciKomputerowych magazyn = MagazynCzesciPC.instancja();
    
    
    @Override
    public Komputer pobierz(TypKomputera typ) {
        switch(typ){
            case PC:{
                komputer = new KomputerPC(magazyn);
                komputer.setModel("PC");
                break;
            }
            case PCzDodatkiem: {
                komputer = new KomputerLaptopzDodatkiem(magazyn);
                komputer.setModel("PC z dodatkiem");
                break;
            }
        }
        return komputer;
    }
    
    
}
