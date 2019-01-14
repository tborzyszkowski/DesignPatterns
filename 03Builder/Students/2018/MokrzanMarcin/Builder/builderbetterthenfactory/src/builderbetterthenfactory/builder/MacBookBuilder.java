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
public abstract class MacBookBuilder {
    protected Mac mac;
    
    public Mac getMac(){
        return mac;
    }
    
    public void createNewMacProduct(){
        mac = new Mac();
    }
    
    public abstract void buildProcesor();
    public abstract void buildRam();
    public abstract void buildHardDisc();
    public abstract void buildGraphicsCard();
    
}
