package StaticHolder;

public class SingletonStaticHolder {
    private SingletonStaticHolder() {
        System.out.println("Utworzono SingletonStaticHolder");
    }

    private static class Holder {
        private static final SingletonStaticHolder INSTANCE = new SingletonStaticHolder();
    }

    public static SingletonStaticHolder getInstance() {
        return Holder.INSTANCE;
    }
}
