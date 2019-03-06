import java.util.HashMap;
import java.util.Set;
import java.util.HashSet;

class SingletonTest2 {
  public static HashMap<String, Integer> hm = new HashMap<String, Integer>();

  public static void main(String[] args) {
    ThreadTest tt1 = new ThreadTest();
    ThreadTest tt2 = new ThreadTest();
    ThreadTest tt3 = new ThreadTest();

    Thread thread1 = new Thread(tt1, "[Thread_01]");
    Thread thread2 = new Thread(tt2, "[Thread_02]");
    Thread thread3 = new Thread(tt3, "[Thread_03]");
    Thread thread4 = new Thread(tt1, "[Thread_04]");
    Thread thread5 = new Thread(tt1, "[Thread_05]");

    thread1.start();
    thread2.start();
    thread3.start();
    thread4.start();
    thread5.start();

    try {
      for (Thread thread : new Thread[] { thread1, thread2, thread3, thread4, thread5 }) {
        thread.join();
      }
    } catch (InterruptedException ie) {
      ie.printStackTrace();
    }

    Helper.compareSetOfInstances();
  }
}
