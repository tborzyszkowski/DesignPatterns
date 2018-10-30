/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package threadsafesingleton;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Random;

/**
 *
 * @author Marcin
 */
public class ThreadSafeSingleton {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
     
        List<Thread> threadList = new ArrayList<>();
        int counter = 0;
        while(counter < (new Random()).nextInt(200)+300 ) { 
            threadList.add(new Thread(() -> {
               SingletonClass.getInstance();
            }));
            counter++;
        }
        
        Date timeCounter = new Date();
        long startTime = timeCounter.getTime();
        for(Thread thread: threadList){
            thread.start();
            System.out.println("It's starting thread: " + thread.getId());
        }
        long endTime = timeCounter.getTime();
        System.out.println("Finished in: " + (endTime - startTime) + " ms" );
    }
    
}
