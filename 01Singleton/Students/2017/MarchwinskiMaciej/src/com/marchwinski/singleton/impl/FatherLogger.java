package com.marchwinski.singleton.impl;

import com.marchwinski.singleton.api.ILogger;

public class FatherLogger implements ILogger {
    private static FatherLogger uniqueInstance;

    FatherLogger() {
        System.out.println("Father has been created.");
    }

    public static synchronized FatherLogger getInstance() {
        if (uniqueInstance == null) {
            System.out.println("Father was null");
            uniqueInstance = new FatherLogger();
        }
        return uniqueInstance;
    }

    public String toString() {
        return "I'm your father";
    }

    @Override
    public void log(String message) {
        System.out.println("FatherLogger :: " + message);
    }
}
