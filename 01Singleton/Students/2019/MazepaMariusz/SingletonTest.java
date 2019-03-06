class SingletonTest {
  public static void main(String[] args) {
    Singleton instance1 = Singleton.getInstance();
    Singleton instance2 = Singleton.getInstance();
    Helper.compareInstances(instance1, instance2);
  }
}
