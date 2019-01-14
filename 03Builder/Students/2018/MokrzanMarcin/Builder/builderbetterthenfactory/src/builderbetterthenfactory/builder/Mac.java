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
public class Mac {
    public String procesor;
    public String ram;
    public String hardDisc ;
    public String graphicsCard;
    
    public void setProcesor(String procesor) {
        this.procesor = procesor;
    }

    public void setRam(String ram) {
        this.ram = ram;
    }

    public void setHardDisc(String hardDisc) {
        this.hardDisc = hardDisc;
    }

    public void setGraphicsCard(String graphicsCard) {
        this.graphicsCard = graphicsCard;
    }
    
    @Override
    public String toString() {
        return "MacBook:" + "\n" 
                + "procesor = " + procesor + "\n"  
                + "ram = " + ram + "\n" 
                + "hardDisc = " + hardDisc + "\n" 
                + "graphicsCard = " + graphicsCard;
    }
    
}

    