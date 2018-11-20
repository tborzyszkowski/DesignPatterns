/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package simplefactory;

/**
 *
 * @author Marcin
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        Game produkt1 = GameSimpleFactory.getGame("HejToMojaRyba", "Gra planszowa: familijna", "ok. 20 minut", " 2-4 osoby", "od 8 lat");
        Game produkt2 = GameSimpleFactory.getGame("JungleSpeed", "Gra planszowa: imprezowa", "ok. 10 - 15 minut", " 2-10 osób", "od 7 lat");
        Game produkt3 = GameSimpleFactory.getGame("SmallWorld", "Gra planszowa: strategiczna", "ok. 60 - 90 minut", " 2-5 osób", "od 8 lat");
        Game produkt4 = GameSimpleFactory.getGame("Zlodzieje", "Gra karciana", "ok. 20 minut", " 3-6 osoby", "od 8 lat");
     
        System.out.println(produkt1.toString());
        System.out.println(produkt2.toString());
        System.out.println(produkt3.toString());
        System.out.println(produkt4.toString());
    }
    
}
