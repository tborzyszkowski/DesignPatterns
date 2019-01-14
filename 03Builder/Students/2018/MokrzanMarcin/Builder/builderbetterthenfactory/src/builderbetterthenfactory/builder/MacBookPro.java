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
public class MacBookPro extends MacBookBuilder {
    
    @Override
    public void buildProcesor() {
        mac.setProcesor("Intel Core i7 2,6 Ghz");
    }
    
    @Override
    public void buildRam() {
        mac.setRam("16 GB ddr4 2400 MHz");
    }
    
    @Override
    public void buildHardDisc() {
        mac.setHardDisc("1 TB SSD");
    }
    
    @Override
    public void buildGraphicsCard() {
        mac.setGraphicsCard("Radeon Pro Vega 20 4GB");
    }
}
