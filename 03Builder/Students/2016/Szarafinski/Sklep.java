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
public class Sklep {
    public Komputer wydaj(zestawKomputerowy budowniczy){
        Komputer komputer = budowniczy.nowyZestaw();
        komputer.przygotuj();
        komputer.pakuj();
        return komputer;
    }
}
