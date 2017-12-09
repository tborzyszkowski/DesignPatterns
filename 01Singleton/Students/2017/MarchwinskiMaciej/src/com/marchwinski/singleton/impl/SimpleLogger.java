package com.marchwinski.singleton.impl;

import com.marchwinski.singleton.api.ILogger;

public class SimpleLogger implements ILogger {
    private static SimpleLogger ourInstance;

    public static SimpleLogger getInstance() {
        if (ourInstance == null) {
            ourInstance = new SimpleLogger();
        }
        return ourInstance;    }

    private SimpleLogger() {
        System.out.println("Constructor : Creating Simple Logger");
    }

    @Override
    public void log(String message) {
        System.out.println("SimpleLogger :: " + message);
    }
}
