import java.util.Set;
import java.util.HashSet;

class Helper {
  public static void compareInstances(Singleton instance1, Singleton instance2) {
    System.out.println("[Instance_01]: " + instance1.hashCode());
    System.out.println("[Instance_02]: " + instance2.hashCode());

    if (instance1.hashCode() == instance2.hashCode()) {
        System.out.println("Instancje identyczne!");
    } else {
        System.out.println("Instancje różnią się!");
    }
  }

  public static void compareSetOfInstances() {
    Set<Integer> values = new HashSet<Integer>(SingletonTest2.hm.values());
    if (values.size() == 1) {
      System.out.println("Wszystkie instancje są identyczne!");
    } else {
      System.out.println("Instancje różnią się!");
    }
  }
}
