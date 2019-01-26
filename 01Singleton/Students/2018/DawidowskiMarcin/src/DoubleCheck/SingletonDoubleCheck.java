package DoubleCheck;

public class SingletonDoubleCheck {
    private static volatile SingletonDoubleCheck instance;

    public static SingletonDoubleCheck getInstance() {
        if (instance == null) {
            synchronized (SingletonDoubleCheck.class) {
                if (instance == null) {
                    System.out.println("Utworzono SingletonDoubleCheck");
                    instance = new SingletonDoubleCheck();
                }
            }
        }
        return instance;
    }
}