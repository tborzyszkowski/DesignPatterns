package com.marchwinski.singleton.impl;

import com.marchwinski.singleton.api.ILogger;

public class MethodSynchronizedLogger implements ILogger {
    private static MethodSynchronizedLogger ourInstance;

    public synchronized static MethodSynchronizedLogger getInstance() {
        if (ourInstance == null) {
            ourInstance = new MethodSynchronizedLogger();
        }
        return ourInstance;
    }

    private MethodSynchronizedLogger() {
        System.out.println("Constructor : Creating MethodSynchronizedLogger");
    }

    @Override
    public void log(String message) {
        System.out.println("MethodSynchronizedLogger :: " + message);
    }
}
