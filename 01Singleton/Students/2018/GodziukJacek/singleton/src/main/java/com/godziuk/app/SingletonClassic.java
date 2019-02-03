/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app;

/**
 *
 * @author jgodziuk
 */
public class SingletonClassic {
    private static SingletonClassic instance = null;
    public String name;
    
    private SingletonClassic(){
        System.out.println("New SingletonClassic has been created");
        
    }

    public static SingletonClassic getInstance(){
        if(instance == null){
            instance = new SingletonClassic(); 
        }
        return instance;
    }
}
