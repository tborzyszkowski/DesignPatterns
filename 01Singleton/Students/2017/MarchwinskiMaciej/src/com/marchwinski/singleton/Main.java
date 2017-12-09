package com.marchwinski.singleton;

import static com.marchwinski.singleton.utils.TestUtils.testLoggerWithThreads;
import static com.marchwinski.singleton.utils.TestUtils.testParentHood;

/**
 * Main class for Singleton Design Pattern testing.
 * Covers thread-safe solutions and inheritance.
 */
public class Main {

    private static final String SIMPLE_LOGGER = "com.marchwinski.singleton.impl.SimpleLogger";
    private static final String METHOD_SYNCHRONIZED_LOGGER = "com.marchwinski.singleton.impl.MethodSynchronizedLogger";

    public static void main(String[] args) {
        testLoggerWithThreads(SIMPLE_LOGGER);
        testLoggerWithThreads(METHOD_SYNCHRONIZED_LOGGER);
        testParentHood();
    }
}
