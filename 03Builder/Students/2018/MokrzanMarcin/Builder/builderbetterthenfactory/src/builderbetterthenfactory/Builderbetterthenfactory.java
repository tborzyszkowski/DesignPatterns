/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package builderbetterthenfactory;

import builderbetterthenfactory.builder.Mac;
import builderbetterthenfactory.builder.MacBookAir;
import builderbetterthenfactory.builder.MacBookBuilder;
import builderbetterthenfactory.builder.MacBookPro;
import builderbetterthenfactory.builder.Macbook;
import builderbetterthenfactory.builder.Seller;

import builderbetterthenfactory.factory.AbstractFactory;
import builderbetterthenfactory.factory.FactoryProducer;
import builderbetterthenfactory.factory.Mac1;

/**
 *
 * @author Marcin
 */
public class Builderbetterthenfactory {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        long startTimeBuilder = System.nanoTime();
        Seller seller = new Seller();
        MacBookBuilder macBook = new Macbook();
        MacBookBuilder macBookPro = new MacBookPro();
        MacBookBuilder macBookAir = new MacBookAir();
        
        seller.setMacBookBuilder(macBook);
        seller.constructMac();
        Mac mac1 = seller.getMac();
        
        seller.setMacBookBuilder(macBookPro);
        seller.constructMac();
        Mac mac2 = seller.getMac();
        
        seller.setMacBookBuilder(macBookAir);
        seller.constructMac();
        Mac mac3 = seller.getMac();
        long endTimeBuilder = System.nanoTime() - startTimeBuilder;
        
        System.out.println("===== Builder =====");
        System.out.println(endTimeBuilder);
        System.out.println(mac1.toString());
        System.out.println(mac2.toString());
        System.out.println(mac3.toString());
        
        long startTimeFactory = System.nanoTime();
        AbstractFactory MacFactory = FactoryProducer.getFactory("Mac1");
        
        Mac1 mac4 = MacFactory.getMac1("MacBook");
        Mac1 mac5 = MacFactory.getMac1("MacBookAir");
        Mac1 mac6 = MacFactory.getMac1("MacBookPro");
        long endTimeFactory = System.nanoTime() - startTimeFactory;
        
        System.out.println("===== Factory =====" );
        System.out.println(endTimeFactory);
        System.out.println(mac4.toString());
        System.out.println(mac5.toString());
        System.out.println(mac6.toString());
        
    }
    
}
