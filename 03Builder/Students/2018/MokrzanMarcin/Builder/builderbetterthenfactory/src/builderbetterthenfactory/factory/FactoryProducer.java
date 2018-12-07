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
public class FactoryProducer {
    public static AbstractFactory getFactory(String choice){
        
        if(choice.equalsIgnoreCase("MAC1")){
            return new MacFactory();
        }
        return null;
    }
}
