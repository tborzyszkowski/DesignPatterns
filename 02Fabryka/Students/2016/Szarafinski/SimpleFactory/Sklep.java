/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactorySimple;

/**
 *
 * @author KrzysieK
 */
public class Sklep {

    Fabryka magazyn;

    public Sklep(Fabryka fabryka) {
        this.magazyn = fabryka;
    }

    public Komputer zamow(TypyKomputerow typ) {
        Komputer komputer = magazyn.stworz(typ);
        przygotuj(komputer);
        pakuj(komputer);
        return komputer;
    }

    public void przygotuj(Komputer komputer) {
        System.out.println("Składam komputer, model nr: " + komputer.model);
    }

    public void pakuj(Komputer komputer) {
        System.out.println("Pakuję komputer, model nr: " + komputer.model);
    }
}
