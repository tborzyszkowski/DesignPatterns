import java.util.Map;
import java.util.TreeMap;

class SimpleThread implements Runnable {
  public static Map<String, Integer> hashCodes = new TreeMap<String, Integer>();

  @Override
  public void run() {
    String threadName = Thread.currentThread().getName();
    int hashCode;
    System.out.println(threadName + " rozpoczął działanie.");
    hashCode = Singleton.getInstance().hashCode();
    synchronized (SimpleThread.class) {
      hashCodes.put(threadName, hashCode);
    }
    System.out.println(threadName + " zakończył działanie (hashCode: " + hashCode + ").");
  }
}
