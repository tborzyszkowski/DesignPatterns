/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package builderbetterthenfactory.factory;

/**
 *
 * @author Marcin
 */
public abstract class Mac1 {
    public String productName;
    public String procesor;
    public String ram;
    public String hardDisc ;
    public String graphicsCard;
    
    public String getProductName() {
        return productName;
    }

    public String getProcesor() {
        return procesor;
    }

    public String getRam() {
        return ram;
    }

    public String getHardDisc() {
        return hardDisc;
    }

    public String getGraphicsCard() {
        return graphicsCard;
    }
    
    @Override
    public String toString() {
        return "" + productName + "\n" 
                + "procesor = " + procesor + "\n"  
                + "ram = " + ram + "\n" 
                + "hardDisc = " + hardDisc + "\n" 
                + "graphicsCard = " + graphicsCard;
    }
}
