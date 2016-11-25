package inheritance;

public enum OtherSingleton implements SingletonInterface {
    INSTANCE;

    private OtherSingleton() {

    }

    @Override
    public void doSomething() {
        Singleton.INSTANCE.doSomething();
    }

    @Override
    public void doSomethingElse() {
        Singleton.INSTANCE.doSomethingElse();
    }

    public void doSomethingElse2() {
        System.out.println("Something else 2!");
    }

    public static OtherSingleton getInstance() {
        return INSTANCE;
    }
}
