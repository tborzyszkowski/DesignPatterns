/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app.Plansza;

/**
 *
 * @author jgodziuk
 */
public class Plansza {
    private static Plansza instance = null;
    public String[][] pola = new String[10][10];
    
    private Plansza(){
        System.out.println("Utworzono plansze");
    }
    
    public static Plansza getInstance(){
        if(instance == null){
            synchronized(Plansza.class){
                if(instance == null){
                   instance = new Plansza(); 
                }
            }
        }
        return instance;
    }
}
