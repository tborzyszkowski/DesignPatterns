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
public class Start {
    public static void main(String[] args){
        Sklep sklep = new Sklep();
        Komputer asus = sklep.wydaj(new AsusG751());
        System.out.println(asus.toString());
        
        Komputer pecet = sklep.wydaj(new PC553());
        System.out.println(pecet.toString());
        
        Komputer dell = sklep.wydaj(new Dell7348());
        System.out.println(dell.toString());
        
    }
}
