/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Singleton;

/**
 *
 * @author KrzysieK
 */
public class Test  {
    
    public static void main(String[] args) {
        System.out.println("Czas wykonania, a wpływ złożoności kodu: ");
         System.out.println(
            "--------------------------------------------------------");
        Singleton obiekt1 = null;
        long start = System.nanoTime();
        for (int i = 1; i < 1000000; i++) {
            obiekt1 = Singleton.instancja();
        }
        long end = System.nanoTime();
        System.out.println("Wywoładnie 1 000 000 instancji " + obiekt1.getClass().getSimpleName() +
                " zajęlo: " + (end - start) / 1000 + " micro sekund");

        SingletonDoubleCheckLocking obiekt2 = null;
        start = System.nanoTime();
        for (int i = 1; i < 1000000; i++) {
            obiekt2 = SingletonDoubleCheckLocking.instancja();
        }
        end = System.nanoTime();
        System.out.println("Wywoładnie 1 000 000 instancji " + obiekt2.getClass().getSimpleName() +
                 " zajęlo: " + (end - start) / 1000 + " micro sekund");
        
        
        Klonowanie klonowanie = new Klonowanie();
        
        Singleton klonObiekt1 = null;
        start = System.nanoTime();
        for (int i = 1; i < 1000; i++) {
            klonObiekt1 = (Singleton)klonowanie.duplikuj(obiekt1);
        }
        end = System.nanoTime();
        System.out.println("Kopiowanie 1 000 instancji " + klonObiekt1.getClass().getSimpleName() +
                " zajęlo: " + (end - start) / 1000 + " micro sekund");
        
        SingletonDoubleCheckLocking klonObiekt2 = null;
        start = System.nanoTime();
        for (int i = 1; i < 1000; i++) {
            klonObiekt2 = (SingletonDoubleCheckLocking)klonowanie.duplikuj(obiekt2);
        }
        end = System.nanoTime();
        System.out.println("Kopiowanie 1 000 instancji " + klonObiekt2.getClass().getSimpleName() +
                 "  zajęlo: " + (end - start) / 1000 + " micro sekund");
        
        System.out.println("\n"+
                "Generowanie ośmiu wątków, które pobierają instancję singletona z zabezpieczeniem i bez");
         System.out.println(
            "--------------------------------------------------------");
        Watek watek1 = new Watek("1.");
        Watek watek2 = new Watek("2.");
        Watek watek3 = new Watek("3.");
        Watek watek4 = new Watek("4.");
        Watek watek5 = new Watek("5.");
        Watek watek6 = new Watek("6.");
        Watek watek7 = new Watek("7.");
        Watek watek8 = new Watek("8.");
        watek1.start();
        watek2.start();
        watek3.start();
        watek4.start();
        watek5.start();
        watek6.start();
        watek7.start();
        watek8.start();
        
    }

   
        

}
