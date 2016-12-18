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
public class Watek implements Runnable {

    private Thread watek;
    private String nazwa;
    SingletonTest bezSynchro;
    SingletonTestDCL zSynchro;

    Watek(String nazwa) {
        this.nazwa = nazwa;
    }

    @Override
    public void run() {

        System.out.println("Wątek " + nazwa + " rozpoczyna wykonywanie instrukcji");
        try {
            System.out.println("Wątek " + nazwa + " pobiera instancję obu singletonów (bez i z sychronizacji)");
            bezSynchro = SingletonTest.instancja(nazwa);
            zSynchro = SingletonTestDCL.instancja(nazwa);
            Thread.sleep(5);

        } catch (InterruptedException e) {
            System.out.println("Wątek " + nazwa + " - błąd.");
        }
        System.out.println("Wątek " + nazwa + " kończy pracę.");
    }

    public void start() {
        System.out.println("Start wątku o ID = " + nazwa);
        if (watek == null) {
            watek = new Thread(this, nazwa);
            watek.start();
        }
    }
}
