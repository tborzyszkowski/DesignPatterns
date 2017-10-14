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
public class Start {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Fabryka fabryka = Fabryka.instancja();
        Sklep sklep = new Sklep(fabryka);

        Komputer komputer1 = sklep.zamow(TypyKomputerow.LAP223);
        System.out.println(komputer1.toString());
        
        Komputer komputer2 = sklep.zamow(TypyKomputerow.LAP564);
        System.out.println(komputer2.toString());
        
        Komputer komputer3 = sklep.zamow(TypyKomputerow.PC104);
        System.out.println(komputer3.toString());
        
        Komputer komputer4 = sklep.zamow(TypyKomputerow.PC203);
        System.out.println(komputer4.toString());

    }

}
