/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package classregistrationfactory;

/**
 *
 * @author Marcin
 */
public class ProductFactory {
    public static Game getGame(Class newClass){
        if("classregistrationfactory.HejToMojaRyba".equals(newClass.getName())) 
            return new HejToMojaRyba();
        else if("classregistrationfactory.GraOTor".equals(newClass.getName()))
            return new GraOTor();      
        else if("classregistrationfactory.Zlodzieje".equals(newClass.getName())) 
            return new Zlodzieje();
        else 
            return null;
    }
}
