import static org.junit.Assert.*;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.hamcrest.CoreMatchers.*;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.lang.reflect.Field;
import java.io.File;
import java.util.ArrayList;
import java.util.Set;
import java.util.HashSet;

public class SingletonTest {

  static SingletonManager sm = new SingletonManager();
  static String filename = "instance.ser";

  @BeforeClass
  public static void setUpClass() throws FileNotFoundException, IOException, ClassNotFoundException {
    sm.mainHeader();
    System.out.println("Rozpoczęcie testowania...");
    System.out.println("-------------------------------------------------------");
    System.out.println("Tworzenie pliku 'instance.ser'.");
    sm.serialize(Singleton.getInstance(), filename);
    System.out.println("Czyszczenie pamięci, instancja ustawiona na 'null'.");
    resetSingleton(Singleton.class, "instance");
  }

  @AfterClass
  public static void tearDownClass() {
    System.out.println("Usuwanie pliku 'instance.ser'.");
    new File(filename).delete();
    System.out.println("-------------------------------------------------------");
    System.out.println("Testowanie zakończone.");
  }

  @Before
  public void setUp() {
    System.out.println("-------------------------------------------------------");
  }

  @After
  public void tearDown() {
    System.out.println("-------------------------------------------------------");
    System.out.println("Czyszczenie pamięci, instancja ustawiona na 'null'.");
    resetSingleton(Singleton.class, "instance");
  }

  public static void resetSingleton(Class theClass, String fieldName) {
    Field instance;
    try {
      instance = theClass.getDeclaredField(fieldName);
      instance.setAccessible(true);
      instance.set(null, null);
    } catch (Exception e) {
      throw new RuntimeException();
    }
  }

  @Test
  public void simpleSingletonTest() {
    sm.testHeader("Simple Singleton Test");

    Singleton instance1 = Singleton.getInstance();
    Singleton instance2 = Singleton.getInstance();

    assertThat(instance2.hashCode(), equalTo(instance1.hashCode()));
    sm.displayHashCodes(instance1, instance2);
  }

  @Test
  public void threadSafeTest() {
    sm.testHeader("Thread Safe Test");

    ArrayList<Thread> threads = new ArrayList<Thread>();
    int threadsAmount = 50;
    String threadName = "Thread_";

    for (int i = 0; i < threadsAmount; i++) {
      threads.add(new Thread(new SimpleThread(), threadName + (i+1)));
    }

    threads.parallelStream().forEach((thread) -> {
      thread.start();
      try {
        thread.join();
      } catch (InterruptedException ie) {
        ie.printStackTrace();
      }
    });

    System.out.println("\nWszystkie wątki zakończyły działanie.");
    System.out.println("Dostępnych rdzeni: " + Runtime.getRuntime().availableProcessors());
    int hcSize = SimpleThread.hashCodes.size();
    System.out.println("Wątki:             " + threadsAmount + "/" + hcSize + "/" + (threadsAmount-hcSize));

    Set<Integer> hashCodes = new HashSet<Integer>(SimpleThread.hashCodes.values());

    assertThat(SimpleThread.hashCodes.size(), equalTo(threadsAmount));
    assertThat(hashCodes.size(), equalTo(1));
  }

  @Test
  public void serializationWithInstanceTest() throws FileNotFoundException, IOException, ClassNotFoundException {
    sm.testHeader("Serialization WITH Instance Test");

    Singleton instance1 = Singleton.getInstance();
    Singleton instance2;

    sm.serialize(instance1, filename);
    instance2 = sm.deserialize(filename);

    assertThat(instance2, instanceOf(Singleton.class));
    assertThat(instance2.hashCode(), equalTo(instance1.hashCode()));
    sm.displayHashCodes(instance1, instance2);
  }

  @Test
  public void serializationWithoutInstanceTest() throws FileNotFoundException, IOException, ClassNotFoundException {
    sm.testHeader("Serialization WITHOUT Instance Test");

    Singleton instance1 = sm.deserialize(filename);
    Singleton instance2 = Singleton.getInstance();

    assertThat(instance1, instanceOf(Singleton.class));
    assertThat(instance1.hashCode(), equalTo(instance2.hashCode()));
    sm.displayHashCodes(instance1, instance2);
  }
}
