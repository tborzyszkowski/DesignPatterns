package com.marchwinski.singleton.impl;

public class LittleLogger extends FatherLogger {

    private LittleLogger(){
        super();
        System.out.println("Child has been born.");
    }

    @Override
    public String toString() {
        return "I'm your child";
    }

    @Override
    public void log(String message) {
        System.out.println("LittleLogger" + message);
    }
}
