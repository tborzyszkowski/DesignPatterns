package com.company;
import java.io.Serializable;

public class Singleton implements Serializable {

    private static Singleton singleton = new Singleton( );

    public int i = 1;

    private Singleton() { System.out.println(Thread.currentThread().getName());}

    public static Singleton getInstance( ) {
        return singleton;
    }

    public Object readResolve() {
        System.out.println(Thread.currentThread().getName());
        return getInstance( );
    }
}
