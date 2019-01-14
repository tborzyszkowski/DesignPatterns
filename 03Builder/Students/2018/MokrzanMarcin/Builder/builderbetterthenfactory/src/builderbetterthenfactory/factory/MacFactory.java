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
public class MacFactory extends AbstractFactory {
    
    @Override
    public Mac1 getMac1(String productName) {
        Mac1 mac1 = null;
        if("MacBook".equals(productName)) 
            mac1 = new MacBook();
        else if("MacBookPro".equals(productName))
            mac1 = new MacBookPro();
        else if("MacBookAir".equals(productName)) 
            mac1 = new MacBookAir();
        else 
            return null;
        return mac1;
    } 
    
}
