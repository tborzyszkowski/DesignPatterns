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
public class Main {

    /**
     * @param args the command line arguments
     */
    
//    static {
//        try {
//            Class.forName("GraOTor");
//            Class.forName("HejToMojaRyba");
//            Class.forName("Zlodzieje");
//        }catch (ClassNotFoundException any){
//            any.printStackTrace();
//        }
//    }
    public static void main(String[] args) {
        Game produkt1 = ProductFactory.getGame(new HejToMojaRyba().getClass());
        Game produkt2 = ProductFactory.getGame(new GraOTor().getClass());
        Game produkt3 = ProductFactory.getGame(new Zlodzieje().getClass());
        
        System.out.println(produkt1.toString());
        System.out.println(produkt2.toString());
        System.out.println(produkt3.toString());
    }
    
}
