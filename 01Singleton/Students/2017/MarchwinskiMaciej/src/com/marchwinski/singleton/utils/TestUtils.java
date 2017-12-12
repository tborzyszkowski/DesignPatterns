package com.marchwinski.singleton.utils;

import com.marchwinski.singleton.ThreadLoggerTester;
import com.marchwinski.singleton.impl.FatherLogger;
import com.marchwinski.singleton.impl.LittleLogger;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CountDownLatch;

public class TestUtils {

    public static void testLoggerWithThreads(String loggerClassName) {
        System.out.println("---     Test for " + loggerClassName + "      ---");
        CountDownLatch latch = new CountDownLatch(1);
        createLoggerTesters(latch, loggerClassName).forEach(thread -> new Thread(thread).start());
        latch.countDown();
    }

    static List<ThreadLoggerTester> createLoggerTesters(CountDownLatch latch, String loggerClassName) {
        List<ThreadLoggerTester> threads = new ArrayList<>();
        for (int i = 0; i < 100; i++) {
            threads.add(new ThreadLoggerTester(latch, loggerClassName));
        }
        return threads;
    }

    public static void testParentHood() {
        FatherLogger father = FatherLogger.getInstance();
        FatherLogger child =  LittleLogger.getInstance();

        father.log("Hello");
        child.log("Hello");

        System.out.println("Father  : " + father);
        System.out.println("Child : " + child);
    }
}
