package inheritance;

public enum Singleton implements SingletonInterface {
    INSTANCE;

    private Singleton() {

    }

    @Override
    public void doSomething() {
        System.out.println("Something!");
    }

    @Override
    public void doSomethingElse() {
        System.out.println("Something else!");
    }

    public static Singleton getInstance() {
        return INSTANCE;
    }
}
