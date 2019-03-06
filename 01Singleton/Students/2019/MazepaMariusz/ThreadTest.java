class ThreadTest implements Runnable {
  @Override
  public void run() {
    String threadName = Thread.currentThread().getName();
    int hashCode = Singleton.getInstance().hashCode();
    SingletonTest2.hm.put(threadName, hashCode);
    System.out.println(threadName + " : " + hashCode);
  }
}
