/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package builderbetterthenfactory.builder;

/**
 *
 * @author Marcin
 */
public class Macbook extends MacBookBuilder {
    
    @Override
    public void buildProcesor() {
        mac.setProcesor("Intel Core i7 1,4 Ghz");
    }
    
    @Override
    public void buildRam() {
        mac.setRam("16 GB LPDDR3 1866 MHz");
    }
    
    @Override
    public void buildHardDisc() {
        mac.setHardDisc("512GB SSD");
    }
    
    @Override
    public void buildGraphicsCard() {
        mac.setGraphicsCard("Dedicated Graphics Card");
    }
    
}
