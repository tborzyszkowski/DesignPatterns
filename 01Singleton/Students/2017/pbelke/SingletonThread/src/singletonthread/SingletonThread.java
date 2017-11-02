package singletonthread;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 *
 * @author pbelke
 */
public class SingletonThread {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        List<Thread> threads = new ArrayList<>();
        for (int i = 0; i < 100; i++) {
            threads.add(new Thread(() -> {
                SingletonSync.getInstance();
            }));
        }

        System.out.println("S: " + new Date());
        for (Thread thread : threads) {
            thread.start();
        }
        System.out.println("F: " + new Date());
    }
}
