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
public class SingletonDCL {
    private static SingletonDCL instance = null;
    public String name;
    
    private SingletonDCL(){
        System.out.println("New SingletonDCL has been created");
        
    }
    
    public static SingletonDCL getInstance(){
        if(instance == null){
            synchronized(SingletonDCL.class){
                if(instance == null){
                   instance = new SingletonDCL(); 
                }
            }
        }
        return instance;
    }
}
