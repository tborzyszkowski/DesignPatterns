package serializationsingleton;

import java.io.Serializable;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Marcin
 */
public class SingletonClass implements Serializable{
    
    private static final long serialVersionUID = -6859166972099747327L;

    private SingletonClass(){}
    
    private static class SingletonHelper{
        private static final SingletonClass instance = new SingletonClass();
    }
    
    public static SingletonClass getInstance(){
        return SingletonHelper.instance;
    }
    
    protected Object readResolve() {
        return getInstance();
    }
    
}
