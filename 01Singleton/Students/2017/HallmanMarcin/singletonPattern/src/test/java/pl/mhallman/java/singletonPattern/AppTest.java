package pl.mhallman.java.singletonPattern;

import org.apache.log4j.Logger;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import pl.mhallman.java.singletonPattern.singleton.ThreadSafeSingletone;

import java.util.ArrayList;
import java.util.List;

import static java.text.MessageFormat.format;

public class AppTest {
    public static final String PATTERN = "{0}{1}";
    public static final String THREAD_LOGGER_OUTPUT = "Thread with Singleton number :: ";
    private static Logger LOG = Logger.getRootLogger();
    private static ThreadSafeSingletone threadSafeSingletone;
    private List<Thread> threadList;

    @Before
    public void setUp() {
        threadSafeSingletone = null;
        threadList = initializeThreads();
    }

    @Test
    public void testUnique() throws InterruptedException {
        int testThreadNumber = 1;
        for (Thread thread : threadList) {
            LOG.info(format(PATTERN, THREAD_LOGGER_OUTPUT, testThreadNumber));
            thread.start();
            thread.join();
            testThreadNumber++;
        }
    }

    private List<Thread> initializeThreads() {
        List<Thread> threadList = new ArrayList<Thread>();
        for(int i=0; i < 100 ; i++) {
            threadList.add(new Thread(new SingletonTestRunnable()));
        }
        return threadList;
    }

    private static class SingletonTestRunnable implements Runnable {
        public void run() {
            ThreadSafeSingletone reference = ThreadSafeSingletone.getInstance();
            synchronized(AppTest.class) {
                if(threadSafeSingletone == null) {
                    threadSafeSingletone = reference;
                }
            }
            Assert.assertEquals(true, reference == threadSafeSingletone);
        }
    }
}
