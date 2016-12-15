/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package FactoryMethod;

/**
 *
 * @author KrzysieK
 */
public class Start {
    
    public static void main(String[] arg){
        Sklep sklepPC = FabrykaPC.instancja();
        Sklep sklepLAP = FabrykaLapopow.instancja();
        
        Komputer pecet = sklepPC.wydaj(TypKomputera.PC104);
        System.out.println(pecet.toString());
        
        Komputer laptop = sklepLAP.wydaj(TypKomputera.LAP223);
        System.out.println(laptop.toString());
    }
    
}
