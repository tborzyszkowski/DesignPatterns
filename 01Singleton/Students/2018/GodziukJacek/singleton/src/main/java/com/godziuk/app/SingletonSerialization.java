/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.godziuk.app;

import java.io.Serializable;

/**
 *
 * @author jgodziuk
 */
public class SingletonSerialization implements Serializable {

    private static SingletonSerialization instance = null;
    public String name = "nieustalone";

    public static SingletonSerialization getInstance() {
        if (instance == null) {
            synchronized (SingletonSerialization.class) {
                if (instance == null) {
                    instance = new SingletonSerialization();
                }
            }
        }
        return instance;
    }
    
    protected Object readResolve() {
        return instance;
    }
}
