package com.marchwinski.singleton;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.concurrent.CountDownLatch;

public class ThreadLoggerTester implements Runnable {

    private CountDownLatch latch;
    private String loggerClassName;
    private Method getLoggerInstance;

    public ThreadLoggerTester(CountDownLatch latch, String loggerClassName) {
        this.latch = latch;
        this.loggerClassName = loggerClassName;
    }

    @Override
    public void run() {
        try {
            try {
                getLoggerInstance = Class.forName(loggerClassName).getMethod("getInstance", null);
            } catch (Exception e) {
                System.err.println("Coudn't find method or class for class " + loggerClassName + " " + e.getCause());
            }

            //The thread keeps waiting till it is informed
            latch.await();
        } catch (InterruptedException e) {
            System.err.println("Exception in run method :  " + e.getCause());
        }
        try {
            // Invokes method getInstance()
            getLoggerInstance.invoke(null);
        } catch (IllegalAccessException | InvocationTargetException e) {
            e.printStackTrace();
        }

    }
}

