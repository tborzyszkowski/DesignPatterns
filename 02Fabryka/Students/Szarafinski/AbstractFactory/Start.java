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
public class Start {
    public static void main(String[] args){
        Sklep sklepLaptop = new SklepLap();
        Sklep sklepPC = new SklepPC();
        
        Komputer laptop = sklepLaptop.wydaj(TypKomputera.LAPTOP);
        System.out.println(laptop.toString());
               
        Komputer pecet = sklepPC.wydaj(TypKomputera.PC);
        System.out.println(pecet.toString());
        
        Komputer laptop2 = sklepLaptop.wydaj(TypKomputera.LAPTOPzDodatkiem);
        System.out.println(laptop2.toString());
               
        Komputer pecet2 = sklepPC.wydaj(TypKomputera.PCzDodatkiem);
        System.out.println(pecet2.toString());
    }
}
